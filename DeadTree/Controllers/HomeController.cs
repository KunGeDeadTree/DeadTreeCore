using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeadTree.Models;
using DeadTree.Models.DBClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DeadTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeadTreeContext _context;

        public HomeController(DeadTreeContext context) => _context = context;

        public IActionResult Index() => View();

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        public async Task<IActionResult> Fill(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var fn = await _context.GetFaultNameModels.FindAsync(id);

            if (fn == null)
            {
                return NotFound();
            }

            var professor = await _context.GetProfessorModels.FirstOrDefaultAsync();

            var temp = await _context.AddAsync(new QuestionsModel()
            {
                FNId = fn.FNId,
                PId = professor.PId,
                Answer = "请输入应对方案"
            });

            await _context.SaveChangesAsync();

            temp.Entity.FeaturesMappings =
                await _context.GetFeaturesMappingModels.Where(x => x.QId == temp.Entity.QId).ToListAsync();

            temp.Entity.ResultsMappings =
                await _context.GetResultsMappingModels.Where(x => x.QId == temp.Entity.QId).ToListAsync();

            return View(temp.Entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Fill(int id, [Bind("QId,Answer,PId,FNId")] QuestionsModel questionsModel)
        {
            if (id != questionsModel.FNId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(questionsModel);
        }

        // GET: QuestionsModels
        public async Task<IActionResult> Tree(int id)
        {
            var deadTreeContext = _context.GetQuestionsModels
                .Include(q => q.FaultName)
                .Include(q => q.Professor)
                .Include(q => q.FeaturesMappings)
                .Include(q => q.ResultsMappings)
                .Where(x => x.FNId == id);

            return View(await deadTreeContext.ToListAsync());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind("Email,Password")] ProfessorModel professorModel)
        {
            var find = await _context.GetProfessorModels.FirstOrDefaultAsync(x =>
            x.Email == professorModel.Email && x.Password == professorModel.Password);

            if (find != null)
            {
                var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Sid, find.Email));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, find.Type.ToString()));

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddDays(7)
                });

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("Email", "用户名或密码错误！");

            return View(professorModel);
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Regist()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Regist([Bind("PId,Name,PaperworkNumber,Unit,Major,PhoneNumber,Email,WeChat,CardNumber,BankName,Password")] ProfessorModel professorModel)
        {
            if (await _context.GetProfessorModels.AnyAsync(x => x.Email == professorModel.Email))
            {
                ModelState.AddModelError("Email", "该邮箱已被注册");
            }

            if (ModelState.IsValid)
            {
                professorModel.Type = Models.EnumClass.EnumAccountType.专家;
                _context.Add(professorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professorModel);
        }
    }
}

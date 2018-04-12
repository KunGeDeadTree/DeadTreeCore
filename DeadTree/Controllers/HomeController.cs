using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeadTree.Models;
using DeadTree.Models.DBClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeadTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeadTreeContext _context;

        public HomeController(DeadTreeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

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
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

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

            return View(new QuestionsModel()
            {
                FNId = fn.FNId,
                PId = professor.PId,
                Answer = "请输入应对方案"
            });
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

    }
}

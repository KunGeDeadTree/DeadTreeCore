using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeadTree.Models.DBClass;

namespace DeadTree.Controllers
{
    public class ProfessorModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public ProfessorModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: ProfessorModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetProfessorModels.ToListAsync());
        }

        // GET: ProfessorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorModel = await _context.GetProfessorModels
                .SingleOrDefaultAsync(m => m.PId == id);
            if (professorModel == null)
            {
                return NotFound();
            }

            return View(professorModel);
        }

        // GET: ProfessorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfessorModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PId,Name,PaperworkNumber,Unit,Major,PhoneNumber,Email,WeChat,CardNumber,BankName")] ProfessorModel professorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professorModel);
        }

        // GET: ProfessorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorModel = await _context.GetProfessorModels.SingleOrDefaultAsync(m => m.PId == id);
            if (professorModel == null)
            {
                return NotFound();
            }
            return View(professorModel);
        }

        // POST: ProfessorModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PId,Name,PaperworkNumber,Unit,Major,PhoneNumber,Email,WeChat,CardNumber,BankName")] ProfessorModel professorModel)
        {
            if (id != professorModel.PId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorModelExists(professorModel.PId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(professorModel);
        }

        // GET: ProfessorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorModel = await _context.GetProfessorModels
                .SingleOrDefaultAsync(m => m.PId == id);
            if (professorModel == null)
            {
                return NotFound();
            }

            return View(professorModel);
        }

        // POST: ProfessorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professorModel = await _context.GetProfessorModels.SingleOrDefaultAsync(m => m.PId == id);
            _context.GetProfessorModels.Remove(professorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorModelExists(int id)
        {
            return _context.GetProfessorModels.Any(e => e.PId == id);
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeadTree.Models.DBClass;

namespace DeadTree.Controllers
{
    public class FaultNameModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public FaultNameModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: FaultNameModels
        public async Task<IActionResult> Index()
        {
            //LINQ用法
            //var c = from bit in _context.GetApparatusModels
            //        where bit.AId < 20
            //        select bit;

            return View(await _context.GetFaultNameModels.ToListAsync());
        }

        public async Task<IActionResult> UserIndex(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return View(await _context.GetFaultNameModels.ToListAsync());
            }
            return View(await _context.GetFaultNameModels.Where(x => x.Name.Contains(name)).ToListAsync());
        }

        // GET: FaultNameModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultNameModel = await _context.GetFaultNameModels
                .SingleOrDefaultAsync(m => m.FNId == id);
            if (faultNameModel == null)
            {
                return NotFound();
            }

            return View(faultNameModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FNId,Name")] FaultNameModel faultNameModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faultNameModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faultNameModel);
        }

        // GET: FaultNameModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultNameModel = await _context.GetFaultNameModels.SingleOrDefaultAsync(m => m.FNId == id);
            if (faultNameModel == null)
            {
                return NotFound();
            }
            return View(faultNameModel);
        }

        // POST: FaultNameModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FNId,Name")] FaultNameModel faultNameModel)
        {
            if (id != faultNameModel.FNId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faultNameModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaultNameModelExists(faultNameModel.FNId))
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
            return View(faultNameModel);
        }

        // GET: FaultNameModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultNameModel = await _context.GetFaultNameModels
                .SingleOrDefaultAsync(m => m.FNId == id);
            if (faultNameModel == null)
            {
                return NotFound();
            }

            return View(faultNameModel);
        }

        // POST: FaultNameModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faultNameModel = await _context.GetFaultNameModels.SingleOrDefaultAsync(m => m.FNId == id);
            _context.GetFaultNameModels.Remove(faultNameModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaultNameModelExists(int id)
        {
            return _context.GetFaultNameModels.Any(e => e.FNId == id);
        }
    }
}

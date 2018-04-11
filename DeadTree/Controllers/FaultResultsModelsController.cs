using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeadTree.Models.DBClass;

namespace DeadTree.Controllers
{
    public class FaultResultsModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public FaultResultsModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: FaultResultsModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetFaultResultsModels.ToListAsync());
        }

        // GET: FaultResultsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultResultsModel = await _context.GetFaultResultsModels
                .SingleOrDefaultAsync(m => m.FRId == id);
            if (faultResultsModel == null)
            {
                return NotFound();
            }

            return View(faultResultsModel);
        }

        // GET: FaultResultsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FaultResultsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FRId,Result")] FaultResultsModel faultResultsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faultResultsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faultResultsModel);
        }

        // GET: FaultResultsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultResultsModel = await _context.GetFaultResultsModels.SingleOrDefaultAsync(m => m.FRId == id);
            if (faultResultsModel == null)
            {
                return NotFound();
            }
            return View(faultResultsModel);
        }

        // POST: FaultResultsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FRId,Result")] FaultResultsModel faultResultsModel)
        {
            if (id != faultResultsModel.FRId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faultResultsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaultResultsModelExists(faultResultsModel.FRId))
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
            return View(faultResultsModel);
        }

        // GET: FaultResultsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultResultsModel = await _context.GetFaultResultsModels
                .SingleOrDefaultAsync(m => m.FRId == id);
            if (faultResultsModel == null)
            {
                return NotFound();
            }

            return View(faultResultsModel);
        }

        // POST: FaultResultsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faultResultsModel = await _context.GetFaultResultsModels.SingleOrDefaultAsync(m => m.FRId == id);
            _context.GetFaultResultsModels.Remove(faultResultsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaultResultsModelExists(int id)
        {
            return _context.GetFaultResultsModels.Any(e => e.FRId == id);
        }
    }
}

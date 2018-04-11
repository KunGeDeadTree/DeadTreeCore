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
    public class FaultFeaturesModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public FaultFeaturesModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: FaultFeaturesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetFaultFeaturesModels.ToListAsync());
        }

        // GET: FaultFeaturesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultFeaturesModel = await _context.GetFaultFeaturesModels
                .SingleOrDefaultAsync(m => m.FFId == id);
            if (faultFeaturesModel == null)
            {
                return NotFound();
            }

            return View(faultFeaturesModel);
        }

        // GET: FaultFeaturesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FaultFeaturesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FFId,Name")] FaultFeaturesModel faultFeaturesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faultFeaturesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faultFeaturesModel);
        }

        // GET: FaultFeaturesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultFeaturesModel = await _context.GetFaultFeaturesModels.SingleOrDefaultAsync(m => m.FFId == id);
            if (faultFeaturesModel == null)
            {
                return NotFound();
            }
            return View(faultFeaturesModel);
        }

        // POST: FaultFeaturesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FFId,Name")] FaultFeaturesModel faultFeaturesModel)
        {
            if (id != faultFeaturesModel.FFId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faultFeaturesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaultFeaturesModelExists(faultFeaturesModel.FFId))
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
            return View(faultFeaturesModel);
        }

        // GET: FaultFeaturesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultFeaturesModel = await _context.GetFaultFeaturesModels
                .SingleOrDefaultAsync(m => m.FFId == id);
            if (faultFeaturesModel == null)
            {
                return NotFound();
            }

            return View(faultFeaturesModel);
        }

        // POST: FaultFeaturesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faultFeaturesModel = await _context.GetFaultFeaturesModels.SingleOrDefaultAsync(m => m.FFId == id);
            _context.GetFaultFeaturesModels.Remove(faultFeaturesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaultFeaturesModelExists(int id)
        {
            return _context.GetFaultFeaturesModels.Any(e => e.FFId == id);
        }
    }
}

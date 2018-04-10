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
    public class FaultMappingModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public FaultMappingModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: FaultMappingModels
        public async Task<IActionResult> Index()
        {
            var deadTreeContext = _context.GetFaultMappingModels.Include(f => f.Component).Include(f => f.FaultFeatures).Include(f => f.FaultName);
            return View(await deadTreeContext.ToListAsync());
        }

        // GET: FaultMappingModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultMappingModel = await _context.GetFaultMappingModels
                .Include(f => f.Component)
                .Include(f => f.FaultFeatures)
                .Include(f => f.FaultName)
                .SingleOrDefaultAsync(m => m.FMId == id);
            if (faultMappingModel == null)
            {
                return NotFound();
            }

            return View(faultMappingModel);
        }

        // GET: FaultMappingModels/Create
        public IActionResult Create()
        {
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name");
            ViewData["FFId"] = new SelectList(_context.GetFaultFeaturesModels, "FFId", "Name");
            ViewData["FNId"] = new SelectList(_context.GetFaultNameModels, "FNId", "Name");
            return View();
        }

        // POST: FaultMappingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FMId,FNId,FFId,CId")] FaultMappingModel faultMappingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faultMappingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name", faultMappingModel.CId);
            ViewData["FFId"] = new SelectList(_context.GetFaultFeaturesModels, "FFId", "Name", faultMappingModel.FFId);
            ViewData["FNId"] = new SelectList(_context.GetFaultNameModels, "FNId", "Name", faultMappingModel.FNId);
            return View(faultMappingModel);
        }

        // GET: FaultMappingModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultMappingModel = await _context.GetFaultMappingModels.SingleOrDefaultAsync(m => m.FMId == id);
            if (faultMappingModel == null)
            {
                return NotFound();
            }
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name", faultMappingModel.CId);
            ViewData["FFId"] = new SelectList(_context.GetFaultFeaturesModels, "FFId", "Name", faultMappingModel.FFId);
            ViewData["FNId"] = new SelectList(_context.GetFaultNameModels, "FNId", "Name", faultMappingModel.FNId);
            return View(faultMappingModel);
        }

        // POST: FaultMappingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FMId,FNId,FFId,CId")] FaultMappingModel faultMappingModel)
        {
            if (id != faultMappingModel.FMId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faultMappingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaultMappingModelExists(faultMappingModel.FMId))
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
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name", faultMappingModel.CId);
            ViewData["FFId"] = new SelectList(_context.GetFaultFeaturesModels, "FFId", "Name", faultMappingModel.FFId);
            ViewData["FNId"] = new SelectList(_context.GetFaultNameModels, "FNId", "Name", faultMappingModel.FNId);
            return View(faultMappingModel);
        }

        // GET: FaultMappingModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faultMappingModel = await _context.GetFaultMappingModels
                .Include(f => f.Component)
                .Include(f => f.FaultFeatures)
                .Include(f => f.FaultName)
                .SingleOrDefaultAsync(m => m.FMId == id);
            if (faultMappingModel == null)
            {
                return NotFound();
            }

            return View(faultMappingModel);
        }

        // POST: FaultMappingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faultMappingModel = await _context.GetFaultMappingModels.SingleOrDefaultAsync(m => m.FMId == id);
            _context.GetFaultMappingModels.Remove(faultMappingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaultMappingModelExists(int id)
        {
            return _context.GetFaultMappingModels.Any(e => e.FMId == id);
        }
    }
}

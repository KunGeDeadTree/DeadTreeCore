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
    public class FeaturesMappingModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public FeaturesMappingModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: FeaturesMappingModels
        public async Task<IActionResult> Index()
        {
            var deadTreeContext = _context.GetFeaturesMappingModels.Include(f => f.Component).Include(f => f.FaultFeatures).Include(f => f.Questions);
            return View(await deadTreeContext.ToListAsync());
        }

        // GET: FeaturesMappingModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuresMappingModel = await _context.GetFeaturesMappingModels
                .Include(f => f.Component)
                .Include(f => f.FaultFeatures)
                .Include(f => f.Questions)
                .SingleOrDefaultAsync(m => m.FMId == id);
            if (featuresMappingModel == null)
            {
                return NotFound();
            }

            return View(featuresMappingModel);
        }

        // GET: FeaturesMappingModels/Create
        public IActionResult Create()
        {
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name");
            ViewData["FFId"] = new SelectList(_context.GetFaultFeaturesModels, "FFId", "Name");
            ViewData["QId"] = new SelectList(_context.GetQuestionsModels, "QId", "Answer");
            return View();
        }

        // POST: FeaturesMappingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FMId,FFId,CId,Description,QId")] FeaturesMappingModel featuresMappingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(featuresMappingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name", featuresMappingModel.CId);
            ViewData["FFId"] = new SelectList(_context.GetFaultFeaturesModels, "FFId", "Name", featuresMappingModel.FFId);
            ViewData["QId"] = new SelectList(_context.GetQuestionsModels, "QId", "Answer", featuresMappingModel.QId);
            return View(featuresMappingModel);
        }

        // GET: FeaturesMappingModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuresMappingModel = await _context.GetFeaturesMappingModels.SingleOrDefaultAsync(m => m.FMId == id);
            if (featuresMappingModel == null)
            {
                return NotFound();
            }
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name", featuresMappingModel.CId);
            ViewData["FFId"] = new SelectList(_context.GetFaultFeaturesModels, "FFId", "Name", featuresMappingModel.FFId);
            ViewData["QId"] = new SelectList(_context.GetQuestionsModels, "QId", "Answer", featuresMappingModel.QId);
            return View(featuresMappingModel);
        }

        // POST: FeaturesMappingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FMId,FFId,CId,Description,QId")] FeaturesMappingModel featuresMappingModel)
        {
            if (id != featuresMappingModel.FMId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featuresMappingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturesMappingModelExists(featuresMappingModel.FMId))
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
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name", featuresMappingModel.CId);
            ViewData["FFId"] = new SelectList(_context.GetFaultFeaturesModels, "FFId", "Name", featuresMappingModel.FFId);
            ViewData["QId"] = new SelectList(_context.GetQuestionsModels, "QId", "Answer", featuresMappingModel.QId);
            return View(featuresMappingModel);
        }

        // GET: FeaturesMappingModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuresMappingModel = await _context.GetFeaturesMappingModels
                .Include(f => f.Component)
                .Include(f => f.FaultFeatures)
                .Include(f => f.Questions)
                .SingleOrDefaultAsync(m => m.FMId == id);
            if (featuresMappingModel == null)
            {
                return NotFound();
            }

            return View(featuresMappingModel);
        }

        // POST: FeaturesMappingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var featuresMappingModel = await _context.GetFeaturesMappingModels.SingleOrDefaultAsync(m => m.FMId == id);
            _context.GetFeaturesMappingModels.Remove(featuresMappingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturesMappingModelExists(int id)
        {
            return _context.GetFeaturesMappingModels.Any(e => e.FMId == id);
        }
    }
}

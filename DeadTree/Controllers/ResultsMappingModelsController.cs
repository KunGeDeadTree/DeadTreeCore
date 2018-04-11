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
    public class ResultsMappingModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public ResultsMappingModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: ResultsMappingModels
        public async Task<IActionResult> Index()
        {
            var deadTreeContext = _context.GetResultsMappingModels.Include(r => r.Component).Include(r => r.FaultResults).Include(r => r.Questions);
            return View(await deadTreeContext.ToListAsync());
        }

        // GET: ResultsMappingModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultsMappingModel = await _context.GetResultsMappingModels
                .Include(r => r.Component)
                .Include(r => r.FaultResults)
                .Include(r => r.Questions)
                .SingleOrDefaultAsync(m => m.RMId == id);
            if (resultsMappingModel == null)
            {
                return NotFound();
            }

            return View(resultsMappingModel);
        }

        // GET: ResultsMappingModels/Create
        public IActionResult Create()
        {
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name");
            ViewData["FRId"] = new SelectList(_context.GetFaultResultsModels, "FRId", "FRId");
            ViewData["QId"] = new SelectList(_context.GetQuestionsModels, "QId", "Answer");
            return View();
        }

        // POST: ResultsMappingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RMId,FRId,CId,Probability,QId")] ResultsMappingModel resultsMappingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultsMappingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name", resultsMappingModel.CId);
            ViewData["FRId"] = new SelectList(_context.GetFaultResultsModels, "FRId", "FRId", resultsMappingModel.FRId);
            ViewData["QId"] = new SelectList(_context.GetQuestionsModels, "QId", "Answer", resultsMappingModel.QId);
            return View(resultsMappingModel);
        }

        // GET: ResultsMappingModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultsMappingModel = await _context.GetResultsMappingModels.SingleOrDefaultAsync(m => m.RMId == id);
            if (resultsMappingModel == null)
            {
                return NotFound();
            }
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name", resultsMappingModel.CId);
            ViewData["FRId"] = new SelectList(_context.GetFaultResultsModels, "FRId", "FRId", resultsMappingModel.FRId);
            ViewData["QId"] = new SelectList(_context.GetQuestionsModels, "QId", "Answer", resultsMappingModel.QId);
            return View(resultsMappingModel);
        }

        // POST: ResultsMappingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RMId,FRId,CId,Probability,QId")] ResultsMappingModel resultsMappingModel)
        {
            if (id != resultsMappingModel.RMId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultsMappingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultsMappingModelExists(resultsMappingModel.RMId))
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
            ViewData["CId"] = new SelectList(_context.GetComponentModels, "CId", "Name", resultsMappingModel.CId);
            ViewData["FRId"] = new SelectList(_context.GetFaultResultsModels, "FRId", "FRId", resultsMappingModel.FRId);
            ViewData["QId"] = new SelectList(_context.GetQuestionsModels, "QId", "Answer", resultsMappingModel.QId);
            return View(resultsMappingModel);
        }

        // GET: ResultsMappingModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultsMappingModel = await _context.GetResultsMappingModels
                .Include(r => r.Component)
                .Include(r => r.FaultResults)
                .Include(r => r.Questions)
                .SingleOrDefaultAsync(m => m.RMId == id);
            if (resultsMappingModel == null)
            {
                return NotFound();
            }

            return View(resultsMappingModel);
        }

        // POST: ResultsMappingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultsMappingModel = await _context.GetResultsMappingModels.SingleOrDefaultAsync(m => m.RMId == id);
            _context.GetResultsMappingModels.Remove(resultsMappingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultsMappingModelExists(int id)
        {
            return _context.GetResultsMappingModels.Any(e => e.RMId == id);
        }
    }
}

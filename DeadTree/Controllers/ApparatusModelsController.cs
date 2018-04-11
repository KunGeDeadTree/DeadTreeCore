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
    public class ApparatusModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public ApparatusModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: ApparatusModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetApparatusModels.ToListAsync());
        }

        // GET: ApparatusModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apparatusModel = await _context.GetApparatusModels
                .SingleOrDefaultAsync(m => m.AId == id);
            if (apparatusModel == null)
            {
                return NotFound();
            }

            return View(apparatusModel);
        }

        // GET: ApparatusModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApparatusModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AId,Name,Type,Pattern")] ApparatusModel apparatusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apparatusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apparatusModel);
        }

        // GET: ApparatusModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apparatusModel = await _context.GetApparatusModels.SingleOrDefaultAsync(m => m.AId == id);
            if (apparatusModel == null)
            {
                return NotFound();
            }
            return View(apparatusModel);
        }

        // POST: ApparatusModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AId,Name,Type,Pattern")] ApparatusModel apparatusModel)
        {
            if (id != apparatusModel.AId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apparatusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApparatusModelExists(apparatusModel.AId))
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
            return View(apparatusModel);
        }

        // GET: ApparatusModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apparatusModel = await _context.GetApparatusModels
                .SingleOrDefaultAsync(m => m.AId == id);
            if (apparatusModel == null)
            {
                return NotFound();
            }

            return View(apparatusModel);
        }

        // POST: ApparatusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apparatusModel = await _context.GetApparatusModels.SingleOrDefaultAsync(m => m.AId == id);
            _context.GetApparatusModels.Remove(apparatusModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApparatusModelExists(int id)
        {
            return _context.GetApparatusModels.Any(e => e.AId == id);
        }
    }
}

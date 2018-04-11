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
    public class ComponentModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public ComponentModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: ComponentModels
        public async Task<IActionResult> Index()
        {
            var deadTreeContext = _context.GetComponentModels.Include(c => c.Apparatus);
            return View(await deadTreeContext.ToListAsync());
        }

        // GET: ComponentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentModel = await _context.GetComponentModels
                .Include(c => c.Apparatus)
                .SingleOrDefaultAsync(m => m.CId == id);
            if (componentModel == null)
            {
                return NotFound();
            }

            return View(componentModel);
        }

        // GET: ComponentModels/Create
        public IActionResult Create()
        {
            ViewData["AId"] = new SelectList(_context.GetApparatusModels, "AId", "Name");
            return View();
        }

        // POST: ComponentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CId,Name,Specification,AId")] ComponentModel componentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AId"] = new SelectList(_context.GetApparatusModels, "AId", "Name", componentModel.AId);
            return View(componentModel);
        }

        // GET: ComponentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentModel = await _context.GetComponentModels.SingleOrDefaultAsync(m => m.CId == id);
            if (componentModel == null)
            {
                return NotFound();
            }
            ViewData["AId"] = new SelectList(_context.GetApparatusModels, "AId", "Name", componentModel.AId);
            return View(componentModel);
        }

        // POST: ComponentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CId,Name,Specification,AId")] ComponentModel componentModel)
        {
            if (id != componentModel.CId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentModelExists(componentModel.CId))
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
            ViewData["AId"] = new SelectList(_context.GetApparatusModels, "AId", "Name", componentModel.AId);
            return View(componentModel);
        }

        // GET: ComponentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentModel = await _context.GetComponentModels
                .Include(c => c.Apparatus)
                .SingleOrDefaultAsync(m => m.CId == id);
            if (componentModel == null)
            {
                return NotFound();
            }

            return View(componentModel);
        }

        // POST: ComponentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var componentModel = await _context.GetComponentModels.SingleOrDefaultAsync(m => m.CId == id);
            _context.GetComponentModels.Remove(componentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentModelExists(int id)
        {
            return _context.GetComponentModels.Any(e => e.CId == id);
        }
    }
}

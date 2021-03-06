﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeadTree.Models.DBClass;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DeadTree.Controllers
{
    public class QuestionsModelsController : Controller
    {
        private readonly DeadTreeContext _context;

        public QuestionsModelsController(DeadTreeContext context)
        {
            _context = context;
        }

        // GET: QuestionsModels
        public async Task<IActionResult> Index()
        {
            var deadTreeContext = _context.GetQuestionsModels.Include(q => q.FaultName).Include(q => q.Professor);
            return View(await deadTreeContext.ToListAsync());
        }

        // GET: QuestionsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsModel = await _context.GetQuestionsModels
                .Include(q => q.FaultName)
                .Include(q => q.Professor)
                .SingleOrDefaultAsync(m => m.QId == id);
            if (questionsModel == null)
            {
                return NotFound();
            }

            return View(questionsModel);
        }

        [Authorize]
        // GET: QuestionsModels/Create
        public IActionResult Create()
        {
            ViewData["FNId"] = new SelectList(_context.GetFaultNameModels, "FNId", "Name");
            //ViewData["PId"] = new SelectList(_context.GetProfessorModels, "PId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QId,Answer,FNId")] QuestionsModel questionsModel)
        {
            if (ModelState.IsValid)
            {
                questionsModel.PId = (await _context.GetProfessorModels
                    .FirstOrDefaultAsync(x => x.Email == User.FindFirst(ClaimTypes.Sid).Value)).PId;

                _context.Add(questionsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FNId"] = new SelectList(_context.GetFaultNameModels, "FNId", "Name", questionsModel.FNId);
            //ViewData["PId"] = new SelectList(_context.GetProfessorModels, "PId", "Name", questionsModel.PId);
            return View(questionsModel);
        }

        // GET: QuestionsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsModel = await _context.GetQuestionsModels
                .Include(x => x.FaultName)
                .Include(x => x.Professor)
                .SingleOrDefaultAsync(m => m.QId == id);

            questionsModel.FeaturesMappings = await _context.GetFeaturesMappingModels
                .Include(x => x.Component)
                .Include(x => x.FaultFeatures)
                .Where(x => x.QId == id).ToListAsync();

            questionsModel.ResultsMappings = await _context.GetResultsMappingModels
                                .Include(x => x.Component)
                                .Include(x => x.FaultResults)
                .Where(x => x.QId == id).ToListAsync();

            if (questionsModel == null)
            {
                return NotFound();
            }
            //ViewData["FNId"] = new SelectList(_context.GetFaultNameModels, "FNId", "Name", questionsModel.FNId);
            //ViewData["PId"] = new SelectList(_context.GetProfessorModels, "PId", "Name", questionsModel.PId);
            return View(questionsModel);
        }

        // POST: QuestionsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QId,Answer,PId,FNId")] QuestionsModel questionsModel)
        {
            if (id != questionsModel.QId)
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
                    if (!QuestionsModelExists(questionsModel.QId))
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
            //ViewData["FNId"] = new SelectList(_context.GetFaultNameModels, "FNId", "Name", questionsModel.FNId);
            //ViewData["PId"] = new SelectList(_context.GetProfessorModels, "PId", "Name", questionsModel.PId);
            return View(questionsModel);
        }

        // GET: QuestionsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionsModel = await _context.GetQuestionsModels
                .Include(q => q.FaultName)
                .Include(q => q.Professor)
                .SingleOrDefaultAsync(m => m.QId == id);
            if (questionsModel == null)
            {
                return NotFound();
            }

            return View(questionsModel);
        }

        // POST: QuestionsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionsModel = await _context.GetQuestionsModels.SingleOrDefaultAsync(m => m.QId == id);
            _context.GetQuestionsModels.Remove(questionsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionsModelExists(int id)
        {
            return _context.GetQuestionsModels.Any(e => e.QId == id);
        }
    }
}

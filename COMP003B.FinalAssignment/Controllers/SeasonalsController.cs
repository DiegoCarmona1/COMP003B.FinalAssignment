using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.FinalAssignment.Data;
using COMP003B.FinalAssignment.Models;

namespace COMP003B.FinalAssignment.Controllers
{
    public class SeasonalsController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public SeasonalsController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: Seasonals
        public async Task<IActionResult> Index()
        {
            var webDevAcademyContext = _context.Seasonals.Include(s => s.Creators).Include(s => s.Recipes);
            return View(await webDevAcademyContext.ToListAsync());
        }

        // GET: Seasonals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasonal = await _context.Seasonals
                .Include(s => s.Creators)
                .Include(s => s.Recipes)
                .FirstOrDefaultAsync(m => m.SeasonalId == id);
            if (seasonal == null)
            {
                return NotFound();
            }

            return View(seasonal);
        }

        // GET: Seasonals/Create
        public IActionResult Create()
        {
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "Season");
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "RecipeName");
            return View();
        }

        // POST: Seasonals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeasonalId,CreatorId,RecipeId")] Seasonal seasonal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seasonal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "Season", seasonal.CreatorId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "RecipeName", seasonal.RecipeId);
            return View(seasonal);
        }

        // GET: Seasonals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasonal = await _context.Seasonals.FindAsync(id);
            if (seasonal == null)
            {
                return NotFound();
            }
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "Season", seasonal.CreatorId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "RecipeName", seasonal.RecipeId);
            return View(seasonal);
        }

        // POST: Seasonals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeasonalId,CreatorId,RecipeId")] Seasonal seasonal)
        {
            if (id != seasonal.SeasonalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seasonal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeasonalExists(seasonal.SeasonalId))
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
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "Season", seasonal.CreatorId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "RecipeId", "RecipeName", seasonal.RecipeId);
            return View(seasonal);
        }

        // GET: Seasonals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasonal = await _context.Seasonals
                .Include(s => s.Creators)
                .Include(s => s.Recipes)
                .FirstOrDefaultAsync(m => m.SeasonalId == id);
            if (seasonal == null)
            {
                return NotFound();
            }

            return View(seasonal);
        }

        // POST: Seasonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seasonal = await _context.Seasonals.FindAsync(id);
            if (seasonal != null)
            {
                _context.Seasonals.Remove(seasonal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasonalExists(int id)
        {
            return _context.Seasonals.Any(e => e.SeasonalId == id);
        }
    }
}

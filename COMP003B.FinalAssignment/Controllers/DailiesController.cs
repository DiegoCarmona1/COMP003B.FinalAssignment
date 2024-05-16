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
    public class DailiesController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public DailiesController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: Dailies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dailys.ToListAsync());
        }

        // GET: Dailies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily = await _context.Dailys
                .FirstOrDefaultAsync(m => m.DailyId == id);
            if (daily == null)
            {
                return NotFound();
            }

            return View(daily);
        }

        // GET: Dailies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dailies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyId,MealTime,CreatorId,RecipeId")] Daily daily)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daily);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daily);
        }

        // GET: Dailies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily = await _context.Dailys.FindAsync(id);
            if (daily == null)
            {
                return NotFound();
            }
            return View(daily);
        }

        // POST: Dailies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DailyId,MealTime,CreatorId,RecipeId")] Daily daily)
        {
            if (id != daily.DailyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daily);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyExists(daily.DailyId))
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
            return View(daily);
        }

        // GET: Dailies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily = await _context.Dailys
                .FirstOrDefaultAsync(m => m.DailyId == id);
            if (daily == null)
            {
                return NotFound();
            }

            return View(daily);
        }

        // POST: Dailies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daily = await _context.Dailys.FindAsync(id);
            if (daily != null)
            {
                _context.Dailys.Remove(daily);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyExists(int id)
        {
            return _context.Dailys.Any(e => e.DailyId == id);
        }
    }
}

﻿using System;
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
    public class RecipesController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public RecipesController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            ViewBag.Creators = from s in _context.Recipes
                              join e in _context.Dailys on s.RecipeId equals e.RecipeId
                              join d in _context.Seasonals on s.RecipeId equals d.RecipeId
                              join f in _context.Holidays on s.RecipeId equals f.RecipeId
                              join c in _context.Creators on e.CreatorId equals c.CreatorId
                              where s.RecipeId == id
                              select c;

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,RecipeName")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,RecipeName")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
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
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeId == id);
        }
    }
}

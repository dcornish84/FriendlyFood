using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FriendlyFood.Data;
using FriendlyFood.Models;

namespace FriendlyFood.Controllers
{
    public class FavoriteMealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoriteMealsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FavoriteMeals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FavoriteMeal.Include(f => f.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FavoriteMeals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMeal = await _context.FavoriteMeal
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteMeal == null)
            {
                return NotFound();
            }

            return View(favoriteMeal);
        }

        // GET: FavoriteMeals/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: FavoriteMeals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,MealId,ApplicationUserId")] FavoriteMeal favoriteMeal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteMeal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", favoriteMeal.ApplicationUserId);
            return View(favoriteMeal);
        }

        // GET: FavoriteMeals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMeal = await _context.FavoriteMeal.FindAsync(id);
            if (favoriteMeal == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", favoriteMeal.ApplicationUserId);
            return View(favoriteMeal);
        }

        // POST: FavoriteMeals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,MealId,ApplicationUserId")] FavoriteMeal favoriteMeal)
        {
            if (id != favoriteMeal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteMeal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteMealExists(favoriteMeal.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", favoriteMeal.ApplicationUserId);
            return View(favoriteMeal);
        }

        // GET: FavoriteMeals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMeal = await _context.FavoriteMeal
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteMeal == null)
            {
                return NotFound();
            }

            return View(favoriteMeal);
        }

        // POST: FavoriteMeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteMeal = await _context.FavoriteMeal.FindAsync(id);
            _context.FavoriteMeal.Remove(favoriteMeal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteMealExists(int id)
        {
            return _context.FavoriteMeal.Any(e => e.Id == id);
        }
    }
}

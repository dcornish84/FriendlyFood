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
    public class FavoriteRestaurantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoriteRestaurantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FavoriteRestaurants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FavoritRestaurant.Include(f => f.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FavoriteRestaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteRestaurant = await _context.FavoritRestaurant
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteRestaurant == null)
            {
                return NotFound();
            }

            return View(favoriteRestaurant);
        }

        // GET: FavoriteRestaurants/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: FavoriteRestaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,RestaurantId,ApplicationUserId")] FavoriteRestaurant favoriteRestaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoriteRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", favoriteRestaurant.ApplicationUserId);
            return View(favoriteRestaurant);
        }

        // GET: FavoriteRestaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteRestaurant = await _context.FavoritRestaurant.FindAsync(id);
            if (favoriteRestaurant == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", favoriteRestaurant.ApplicationUserId);
            return View(favoriteRestaurant);
        }

        // POST: FavoriteRestaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,RestaurantId,ApplicationUserId")] FavoriteRestaurant favoriteRestaurant)
        {
            if (id != favoriteRestaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteRestaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteRestaurantExists(favoriteRestaurant.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", favoriteRestaurant.ApplicationUserId);
            return View(favoriteRestaurant);
        }

        // GET: FavoriteRestaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteRestaurant = await _context.FavoritRestaurant
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteRestaurant == null)
            {
                return NotFound();
            }

            return View(favoriteRestaurant);
        }

        // POST: FavoriteRestaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteRestaurant = await _context.FavoritRestaurant.FindAsync(id);
            _context.FavoritRestaurant.Remove(favoriteRestaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteRestaurantExists(int id)
        {
            return _context.FavoritRestaurant.Any(e => e.Id == id);
        }
    }
}

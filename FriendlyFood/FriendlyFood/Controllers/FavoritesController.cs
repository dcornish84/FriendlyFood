using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FriendlyFood.Data;
using FriendlyFood.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FriendlyFood.Models.ViewModels;

namespace FriendlyFood.Controllers
{


    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoritesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        

        public async Task<IActionResult> Index()
        {
            var favoritesViewModel = new FavoritesViewModel();
            var user = await GetCurrentUserAsync();
            favoritesViewModel.FavoriteRestaurant = await _context.FavoritRestaurant
                .Where(a => a.ApplicationUserId == user.Id).Include(a => a.Restaurant).Include(a => a.Restaurant.Cuisine).ToListAsync();
            favoritesViewModel.FavoriteMeal = await _context.FavoriteMeal
                .Where(a => a.ApplicationUserId == user.Id).Include(a => a.Meal).ToListAsync();
            return View(favoritesViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRestaurantToFavorites(int id)
        {
            var user = await GetCurrentUserAsync();
            var favoriteRestaurant = new FavoriteRestaurant
            {
                ApplicationUserId = user.Id,
                RestaurantId = id
                
            };
            _context.Add(favoriteRestaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Favorites");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMealToFavorites(int id)
        {
            var user = await GetCurrentUserAsync();
            var favoriteMeal = new FavoriteMeal
            {
                ApplicationUserId = user.Id,
                MealId = id

            };
            _context.Add(favoriteMeal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Favorites");
        }




      

        // GET: Favorites/Delete/5

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var favoritesViewModel = new FavoritesViewModel();
            var restaurant = await _context.FavoriteRestaurant
                .Include(r => r.ApplicationUser)
                .Include(r => r.Cuisine)
                .Include(r => r.Id)
                .FirstOrDefaultAsync(m => m.Id == id);
            var meal = await _context.FavoriteMeal
                .Include(m => m.ApplicationUser)
                .Include(m => m.Id)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            if (meal == null)
            {
                return NotFound();
            }



            return View(favoritesViewModel);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.FavoriteRestaurant.FindAsync(id);
            _context.FavoriteRestaurant.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.FavoriteRestaurant.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}

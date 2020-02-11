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
                .Where(a => a.ApplicationUserId == user.Id).Include(a => a.Meal).Include(a => a.Meal.Restaurant).ToListAsync();
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
        // GET: FavoriteRestaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteRestaurant = await _context.FavoritRestaurant
                .Include(f => f.ApplicationUser)
                .Include(f => f.Restaurant)
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

        // GET: FavoriteMeals/Delete/5
        public async Task<IActionResult> DeleteMeal(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteMeal = await _context.FavoriteMeal
                .Include(f => f.ApplicationUser)
                .Include(f => f.Meal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteMeal == null)
            {
                return NotFound();
            }

            return View(favoriteMeal);
        }

        // POST: FavoriteMeals/Delete/5
        [HttpPost, ActionName("DeleteMealConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMealConfirmed(int id)
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
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}

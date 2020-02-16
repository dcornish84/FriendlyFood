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

namespace FriendlyFood.Controllers
{


    public class RestaurantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RestaurantsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index(string searchString)
        { 
        
            var user = await GetCurrentUserAsync();
            var integerTerm = -1;
            Int32.TryParse(searchString, out integerTerm);

            if (searchString == null)
            {
                var model = _context.Restaurant
                    .Include(r => r.Cuisine);
                return View(await model.ToListAsync());
            }
            else
            {
                var model = _context.Restaurant
                 .Include(r => r.Cuisine)
                 .Where(r => r.RestaurantName.Contains(searchString) || r.Address.Contains(searchString) || r.City.Contains(searchString) || r.Cuisine.CuisineName.Contains(searchString) || r.ZipCode == integerTerm);
                return View(await model.ToListAsync());
            }
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant
                .Include(r => r.ApplicationUser)
                .Include(r => r.Cuisine)
                .Include(r => r.RestaurantDiets)
                    .ThenInclude(rd => rd.DietType)
                

                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create

            [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            var cuisine = _context.Cuisine;
            ViewData["CuisineId"] = new SelectList(cuisine, "Id", "CuisineName");
            return View();
        }
        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RestaurantName,Address,ZipCode,City,CuisineId,")] Restaurant restaurant)
        {
            var user = await GetCurrentUserAsync();
            restaurant.ApplicationUserId = user.Id;
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            var cuisine = _context.Cuisine;
            ViewData["CuisineId"] = new SelectList(cuisine, "Id", "CuisineName");


            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RestaurantName,Address,ZipCode,City,CuisineId,ApplicationUserId")] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", restaurant.ApplicationUserId);
            ViewData["CuisineId"] = new SelectList(_context.Cuisine, "Id", "Id", restaurant.CuisineId);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant
                .Include(r => r.ApplicationUser)
                .Include(r => r.Cuisine)
                .Include(r => r.RestaurantDiets)
                    .ThenInclude(rd => rd.DietType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.Restaurant.FindAsync(id);
            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurant.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}

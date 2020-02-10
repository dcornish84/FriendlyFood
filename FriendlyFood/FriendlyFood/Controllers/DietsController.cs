using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendlyFood.Data;
using FriendlyFood.Models;
using FriendlyFood.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FriendlyFood.Controllers
{
    public class DietsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DietsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Diets
        public async Task<IActionResult> Index()
        {
            var dietsviewModel = new DietsViewModel();
             dietsviewModel.RestaurantDiet = await _context.RestaurantDiet.Include(r => r.DietType).ToListAsync();
            dietsviewModel.MealDiet = await _context.MealDiet.Include(r => r.DietType).ToListAsync();
            return View(dietsviewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDietToRestaurant(int id)
        {
            
            var dietRestaurant = new RestaurantDiet
            {
                
                RestaurantId = id

            };
            _context.Add(dietRestaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Restaurant");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDietToMeal(int id)
        {

            var mealRestaurant = new MealDiet
            {

                MealId = id

            };
            _context.Add(mealRestaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Meal");
        }


        // GET: Diets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Diets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Diets/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Diets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Diets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Diets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
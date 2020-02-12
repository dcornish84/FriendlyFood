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
using FriendlyFood.Models.ViewModels;

namespace FriendlyFood.Controllers
{
    public class DietTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DietTypesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: DietTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DietType.ToListAsync());
        }

        // GET: DietTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietType = await _context.DietType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dietType == null)
            {
                return NotFound();
            }

            return View(dietType);
        }

        //get all the RestaurantDietTypes
        public async Task<IActionResult> GetDiet(int id)
        {
            var addDietTagViewModel = new AddDietTagViewModel()
            {
                RestaurantId = id
            };
            var diets =  _context.DietType;
            ViewData["DietTypeId"] = new SelectList(diets, "Id", "DietName");
            return View("AddDietRest", addDietTagViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDietRest(AddDietTagViewModel viewModel)
        {
            var user = await GetCurrentUserAsync();
            viewModel.RestaurantDiets = viewModel.DietTypeIds.Select(dietTypeId => new RestaurantDiet
            {
                
                RestaurantId = viewModel.RestaurantId,
                DietTypeId = dietTypeId,
                

            }).ToList();
            foreach (var restDiet in viewModel.RestaurantDiets)
            {
                _context.RestaurantDiet.Add(restDiet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Restaurants", viewModel.RestaurantId);

        }

        //get all the RestaurantDietTypes
        public async Task<IActionResult> GetMealDiet(int id)
        {
            var addDietTagViewModel = new AddDietTagViewModel()
            {
                MealId = id
            };
            var diets = _context.DietType;
            ViewData["DietTypeId"] = new SelectList(diets, "Id", "DietName");
            return View("AddDietMeal", addDietTagViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDietMeal(AddDietTagViewModel viewModel)
        {
            var user = await GetCurrentUserAsync();
            viewModel.MealDiets = viewModel.DietTypeIds.Select(dietTypeId => new MealDiet
            {

                MealId = viewModel.MealId,
                DietTypeId = dietTypeId,


            }).ToList();
            foreach (var mealDiet in viewModel.MealDiets)
            {
                _context. MealDiet.Add(mealDiet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Meals", viewModel.MealId);

        }





        // GET: DietTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DietTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DietName")] DietType dietType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dietType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dietType);
        }

        // GET: DietTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietType = await _context.DietType.FindAsync(id);
            if (dietType == null)
            {
                return NotFound();
            }
            return View(dietType);
        }

        // POST: DietTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DietName")] DietType dietType)
        {
            if (id != dietType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dietType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietTypeExists(dietType.Id))
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
            return View(dietType);
        }

        // GET: DietTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietType = await _context.DietType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dietType == null)
            {
                return NotFound();
            }

            return View(dietType);
        }

        // POST: DietTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietType = await _context.DietType.FindAsync(id);
            _context.DietType.Remove(dietType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietTypeExists(int id)
        {
            return _context.DietType.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}

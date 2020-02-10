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
    public class DietTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietTypesController(ApplicationDbContext context)
        {
            _context = context;
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
    }
}

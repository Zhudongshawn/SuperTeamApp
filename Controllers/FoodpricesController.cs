using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperTeamApp.Data;
using SuperTeamApp.Models;

namespace SuperTeamApp.Controllers
{
    public class FoodpricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodpricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Foodprices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Foodprices.ToListAsync());
        }

        // GET: Foodprices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodprice = await _context.Foodprices
                .FirstOrDefaultAsync(m => m.FoodId == id);
            if (foodprice == null)
            {
                return NotFound();
            }

            return View(foodprice);
        }

        // GET: Foodprices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foodprices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodId,FoodName,FPrice,PictureUrl")] Foodprice foodprice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodprice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodprice);
        }

        // GET: Foodprices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodprice = await _context.Foodprices.FindAsync(id);
            if (foodprice == null)
            {
                return NotFound();
            }
            return View(foodprice);
        }

        // POST: Foodprices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodId,FoodName,FPrice,PictureUrl")] Foodprice foodprice)
        {
            if (id != foodprice.FoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodprice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodpriceExists(foodprice.FoodId))
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
            return View(foodprice);
        }

        // GET: Foodprices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodprice = await _context.Foodprices
                .FirstOrDefaultAsync(m => m.FoodId == id);
            if (foodprice == null)
            {
                return NotFound();
            }

            return View(foodprice);
        }

        // POST: Foodprices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodprice = await _context.Foodprices.FindAsync(id);
            _context.Foodprices.Remove(foodprice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodpriceExists(int id)
        {
            return _context.Foodprices.Any(e => e.FoodId == id);
        }
    }
}

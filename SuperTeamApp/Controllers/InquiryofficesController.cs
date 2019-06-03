using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperTeamApp.Data;
using SuperTeamApp.Models;

namespace SuperTeamApp.Controllers
{
    public class InquiryofficesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InquiryofficesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inquiryoffices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inquiryoffices.ToListAsync());
        }

        // GET: Inquiryoffices/Details/5
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquiryoffice = await _context.Inquiryoffices
                .FirstOrDefaultAsync(m => m.InquiryId == id);
            if (inquiryoffice == null)
            {
                return NotFound();
            }

            return View(inquiryoffice);
        }

        // GET: Inquiryoffices/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inquiryoffices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InquiryId,FoodName,Question,Answer")] Inquiryoffice inquiryoffice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inquiryoffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inquiryoffice);
        }

        // GET: Inquiryoffices/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquiryoffice = await _context.Inquiryoffices.FindAsync(id);
            if (inquiryoffice == null)
            {
                return NotFound();
            }
            return View(inquiryoffice);
        }

        // POST: Inquiryoffices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InquiryId,FoodName,Question,Answer")] Inquiryoffice inquiryoffice)
        {
            if (id != inquiryoffice.InquiryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inquiryoffice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InquiryofficeExists(inquiryoffice.InquiryId))
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
            return View(inquiryoffice);
        }

        // GET: Inquiryoffices/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquiryoffice = await _context.Inquiryoffices
                .FirstOrDefaultAsync(m => m.InquiryId == id);
            if (inquiryoffice == null)
            {
                return NotFound();
            }

            return View(inquiryoffice);
        }

        // POST: Inquiryoffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inquiryoffice = await _context.Inquiryoffices.FindAsync(id);
            _context.Inquiryoffices.Remove(inquiryoffice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InquiryofficeExists(int id)
        {
            return _context.Inquiryoffices.Any(e => e.InquiryId == id);
        }
    }
}

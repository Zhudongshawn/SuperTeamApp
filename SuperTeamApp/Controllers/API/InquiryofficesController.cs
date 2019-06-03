using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperTeamApp.Data;
using SuperTeamApp.Models;

namespace SuperTeamApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryofficesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InquiryofficesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Inquiryoffices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquiryoffice>>> GetInquiryoffices()
        {
            return await _context.Inquiryoffices.ToListAsync();
        }

        // GET: api/Inquiryoffices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inquiryoffice>> GetInquiryoffice(int id)
        {
            var inquiryoffice = await _context.Inquiryoffices.FindAsync(id);

            if (inquiryoffice == null)
            {
                return NotFound();
            }

            return inquiryoffice;
        }

        // PUT: api/Inquiryoffices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInquiryoffice(int id, Inquiryoffice inquiryoffice)
        {
            if (id != inquiryoffice.InquiryId)
            {
                return BadRequest();
            }

            _context.Entry(inquiryoffice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InquiryofficeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Inquiryoffices
        [HttpPost]
        public async Task<ActionResult<Inquiryoffice>> PostInquiryoffice(Inquiryoffice inquiryoffice)
        {
            _context.Inquiryoffices.Add(inquiryoffice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInquiryoffice", new { id = inquiryoffice.InquiryId }, inquiryoffice);
        }

        // DELETE: api/Inquiryoffices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inquiryoffice>> DeleteInquiryoffice(int id)
        {
            var inquiryoffice = await _context.Inquiryoffices.FindAsync(id);
            if (inquiryoffice == null)
            {
                return NotFound();
            }

            _context.Inquiryoffices.Remove(inquiryoffice);
            await _context.SaveChangesAsync();

            return inquiryoffice;
        }

        private bool InquiryofficeExists(int id)
        {
            return _context.Inquiryoffices.Any(e => e.InquiryId == id);
        }
    }
}

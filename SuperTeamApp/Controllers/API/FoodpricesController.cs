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
    public class FoodpricesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodpricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Foodprices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Foodprice>>> GetFoodprices()
        {
            return await _context.Foodprices.ToListAsync();
        }

        // GET: api/Foodprices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Foodprice>> GetFoodprice(int id)
        {
            var foodprice = await _context.Foodprices.FindAsync(id);

            if (foodprice == null)
            {
                return NotFound();
            }

            return foodprice;
        }

        // PUT: api/Foodprices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodprice(int id, Foodprice foodprice)
        {
            if (id != foodprice.FoodId)
            {
                return BadRequest();
            }

            _context.Entry(foodprice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodpriceExists(id))
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

        // POST: api/Foodprices
        [HttpPost]
        public async Task<ActionResult<Foodprice>> PostFoodprice(Foodprice foodprice)
        {
            _context.Foodprices.Add(foodprice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodprice", new { id = foodprice.FoodId }, foodprice);
        }

        // DELETE: api/Foodprices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Foodprice>> DeleteFoodprice(int id)
        {
            var foodprice = await _context.Foodprices.FindAsync(id);
            if (foodprice == null)
            {
                return NotFound();
            }

            _context.Foodprices.Remove(foodprice);
            await _context.SaveChangesAsync();

            return foodprice;
        }

        private bool FoodpriceExists(int id)
        {
            return _context.Foodprices.Any(e => e.FoodId == id);
        }
    }
}

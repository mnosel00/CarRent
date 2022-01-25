using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRent.Models;

namespace CarRent.Controllers
{
    [Route("api/context")]
    [ApiController]
    public class ApiCarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApiCarsController(AppDbContext context)
        {
            _context = context;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCard()
        {
            return await _context.Card.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Card.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Card.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Card.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Card.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Card.Any(e => e.Id == id);
        }
    }
}

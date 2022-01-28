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
        public ActionResult<IEnumerable<Car>> GetCard()
        {
            return _context.Card.ToList();
        }

       
        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car =  _context.Card.Find(id);
            var car2 =  _context.Companies.Find(id);
            var car3 =  _context.Companies.Find(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

       
        [HttpPut("{id}")]
        public IActionResult PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                 _context.SaveChangesAsync();
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
        public ActionResult<Car> PostCar(Car car)
        {
            _context.Card.Add(car);
             _context.SaveChanges();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

    
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car =  _context.Card.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Card.Remove(car);
            _context.SaveChanges();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Card.Any(e => e.Id == id);
        }
    }
}

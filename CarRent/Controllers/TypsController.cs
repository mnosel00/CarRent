using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRent.Data;
using CarRent.Models;

namespace CarRent.Controllers
{
    public class TypsController : Controller
    {
        private readonly CarRentContext _context;

        public TypsController(CarRentContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            return View(await _context.Typ.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Typ
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typ == null)
            {
                return NotFound();
            }

            return View(typ);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Undercarriage")] Typ typ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typ);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Typ.FindAsync(id);
            if (typ == null)
            {
                return NotFound();
            }
            return View(typ);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Undercarriage")] Typ typ)
        {
            if (id != typ.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypExists(typ.Id))
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
            return View(typ);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Typ
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typ == null)
            {
                return NotFound();
            }

            return View(typ);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typ = await _context.Typ.FindAsync(id);
            _context.Typ.Remove(typ);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypExists(int id)
        {
            return _context.Typ.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using CarRent.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarRent.Controllers
{
    public class TypsController : Controller
    {
        private readonly AppDbContext _context;

        public TypsController(AppDbContext context)
        {
            _context = context;
        }

      
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult List()
        {
            var model = _context.Types.ToList();
            return View(model);
        }



        [Authorize]
        public IActionResult Create()
        {

            ViewBag.Company = _context.Companies.ToList();
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Typ typ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typ);
                await _context.SaveChangesAsync();
                return RedirectToAction("List", new { Id = typ.Id });
            }
            return View(typ);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Types.FindAsync(id);
            if (typ == null)
            {
                return NotFound();
            }
            return View(typ);
        }

        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Typ typ)
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
                return RedirectToAction("List", new { Id = typ.Id });
            }
            return View(typ);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Types
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typ == null)
            {
                return NotFound();
            }

            return View(typ);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typ = await _context.Types.FindAsync(id);
            _context.Types.Remove(typ);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", new { Id = typ.Id });
        }

        private bool TypExists(int id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}

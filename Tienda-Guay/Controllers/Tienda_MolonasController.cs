using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tienda_Guay.Data;
using Tienda_Guay.Models;

namespace Tienda_Guay.Views.Tienda_Molonas
{
    public class Tienda_MolonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Tienda_MolonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tienda_Molonas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tienda_Molona.ToListAsync());
        }

        // GET: Tienda_Molonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienda_Molona = await _context.Tienda_Molona
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tienda_Molona == null)
            {
                return NotFound();
            }

            return View(tienda_Molona);
        }

        // GET: Tienda_Molonas/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tienda_Molonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producto,Categoria,Descripcion,Precio,URL_IMAGEN")] Tienda_Molona tienda_Molona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tienda_Molona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tienda_Molona);
        }

        // GET: Tienda_Molonas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienda_Molona = await _context.Tienda_Molona.FindAsync(id);
            if (tienda_Molona == null)
            {
                return NotFound();
            }
            return View(tienda_Molona);
        }

        // POST: Tienda_Molonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producto,Categoria,Descripcion,Precio,URL_IMAGEN")] Tienda_Molona tienda_Molona)
        {
            if (id != tienda_Molona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tienda_Molona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tienda_MolonaExists(tienda_Molona.Id))
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
            return View(tienda_Molona);
        }

        // GET: Tienda_Molonas/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienda_Molona = await _context.Tienda_Molona
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tienda_Molona == null)
            {
                return NotFound();
            }

            return View(tienda_Molona);
        }

        // POST: Tienda_Molonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tienda_Molona = await _context.Tienda_Molona.FindAsync(id);
            _context.Tienda_Molona.Remove(tienda_Molona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tienda_MolonaExists(int id)
        {
            return _context.Tienda_Molona.Any(e => e.Id == id);
        }
    }
}

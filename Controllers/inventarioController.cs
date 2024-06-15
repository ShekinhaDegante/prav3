using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prav3.Context;
using prav3.Models;

namespace prav3.Controllers
{
    public class inventarioController : Controller
    {
        private readonly Pra3MMAA _context;

        public inventarioController(Pra3MMAA context)
        {
            _context = context;
        }

        // GET: inventario
        public async Task<IActionResult> Index()
        {
              return _context.tInventarios != null ? 
                          View(await _context.tInventarios.ToListAsync()) :
                          Problem("Entity set 'Pra3MMAA.tInventarios'  is null.");
        }

        // GET: inventario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tInventarios == null)
            {
                return NotFound();
            }

            var inventario = await _context.tInventarios
                .FirstOrDefaultAsync(m => m.IDInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: inventario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: inventario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDInventario,FKIDLibro,FKIDSucursal,Existencia")] inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventario);
        }

        // GET: inventario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tInventarios == null)
            {
                return NotFound();
            }

            var inventario = await _context.tInventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            return View(inventario);
        }

        // POST: inventario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDInventario,FKIDLibro,FKIDSucursal,Existencia")] inventario inventario)
        {
            if (id != inventario.IDInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!inventarioExists(inventario.IDInventario))
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
            return View(inventario);
        }

        // GET: inventario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tInventarios == null)
            {
                return NotFound();
            }

            var inventario = await _context.tInventarios
                .FirstOrDefaultAsync(m => m.IDInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tInventarios == null)
            {
                return Problem("Entity set 'Pra3MMAA.tInventarios'  is null.");
            }
            var inventario = await _context.tInventarios.FindAsync(id);
            if (inventario != null)
            {
                _context.tInventarios.Remove(inventario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool inventarioExists(int id)
        {
          return (_context.tInventarios?.Any(e => e.IDInventario == id)).GetValueOrDefault();
        }
    }
}

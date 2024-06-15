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
    public class SucursalController : Controller
    {
        private readonly Pra3MMAA _context;

        public SucursalController(Pra3MMAA context)
        {
            _context = context;
        }

        // GET: Sucursal
        public async Task<IActionResult> Index()
        {
              return _context.tSucursal != null ? 
                          View(await _context.tSucursal.ToListAsync()) :
                          Problem("Entity set 'Pra3MMAA.tSucursal'  is null.");
        }

        // GET: Sucursal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tSucursal == null)
            {
                return NotFound();
            }

            var sucursal = await _context.tSucursal
                .FirstOrDefaultAsync(m => m.IDSucursal == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // GET: Sucursal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sucursal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDSucursal,Nombre,NombreDelEncargado,Direccion,Ciudad,Telefono,Email,Comentario")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sucursal);
        }

        // GET: Sucursal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tSucursal == null)
            {
                return NotFound();
            }

            var sucursal = await _context.tSucursal.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return View(sucursal);
        }

        // POST: Sucursal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDSucursal,Nombre,NombreDelEncargado,Direccion,Ciudad,Telefono,Email,Comentario")] Sucursal sucursal)
        {
            if (id != sucursal.IDSucursal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalExists(sucursal.IDSucursal))
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
            return View(sucursal);
        }

        // GET: Sucursal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tSucursal == null)
            {
                return NotFound();
            }

            var sucursal = await _context.tSucursal
                .FirstOrDefaultAsync(m => m.IDSucursal == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // POST: Sucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tSucursal == null)
            {
                return Problem("Entity set 'Pra3MMAA.tSucursal'  is null.");
            }
            var sucursal = await _context.tSucursal.FindAsync(id);
            if (sucursal != null)
            {
                _context.tSucursal.Remove(sucursal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalExists(int id)
        {
          return (_context.tSucursal?.Any(e => e.IDSucursal == id)).GetValueOrDefault();
        }
    }
}

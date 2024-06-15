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
    public class EditorialController : Controller
    {
        private readonly Pra3MMAA _context;

        public EditorialController(Pra3MMAA context)
        {
            _context = context;
        }

        // GET: Editorial
        public async Task<IActionResult> Index()
        {
              return _context.tEditorial != null ? 
                          View(await _context.tEditorial.ToListAsync()) :
                          Problem("Entity set 'Pra3MMAA.tEditorial'  is null.");
        }

        // GET: Editorial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tEditorial == null)
            {
                return NotFound();
            }

            var editorial = await _context.tEditorial
                .FirstOrDefaultAsync(m => m.IDEditorial == id);
            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }

        // GET: Editorial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editorial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDEditorial,Nombre,NombreDelContacto,Direccion,Ciudad,Telefono,Email,Comentario")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editorial);
        }

        // GET: Editorial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tEditorial == null)
            {
                return NotFound();
            }

            var editorial = await _context.tEditorial.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return View(editorial);
        }

        // POST: Editorial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDEditorial,Nombre,NombreDelContacto,Direccion,Ciudad,Telefono,Email,Comentario")] Editorial editorial)
        {
            if (id != editorial.IDEditorial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialExists(editorial.IDEditorial))
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
            return View(editorial);
        }

        // GET: Editorial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tEditorial == null)
            {
                return NotFound();
            }

            var editorial = await _context.tEditorial
                .FirstOrDefaultAsync(m => m.IDEditorial == id);
            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }

        // POST: Editorial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tEditorial == null)
            {
                return Problem("Entity set 'Pra3MMAA.tEditorial'  is null.");
            }
            var editorial = await _context.tEditorial.FindAsync(id);
            if (editorial != null)
            {
                _context.tEditorial.Remove(editorial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialExists(int id)
        {
          return (_context.tEditorial?.Any(e => e.IDEditorial == id)).GetValueOrDefault();
        }
    }
}

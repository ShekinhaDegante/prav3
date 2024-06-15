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
    public class LibroController : Controller
    {
        private readonly Pra3MMAA _context;

        public LibroController(Pra3MMAA context)
        {
            _context = context;
        }

        // GET: Libro
        public async Task<IActionResult> Index()
        {
              return _context.tLibro != null ? 
                          View(await _context.tLibro.ToListAsync()) :
                          Problem("Entity set 'Pra3MMAA.tLibro'  is null.");
        }

        // GET: Libro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tLibro == null)
            {
                return NotFound();
            }

            var libro = await _context.tLibro
                .FirstOrDefaultAsync(m => m.IDLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDLibro,ISBN,Titulo,Autor,FKIDEditorial,Año,Precio,Comentarios,Foto")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tLibro == null)
            {
                return NotFound();
            }

            var libro = await _context.tLibro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDLibro,ISBN,Titulo,Autor,FKIDEditorial,Año,Precio,Comentarios,Foto")] Libro libro)
        {
            if (id != libro.IDLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IDLibro))
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
            return View(libro);
        }

        // GET: Libro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tLibro == null)
            {
                return NotFound();
            }

            var libro = await _context.tLibro
                .FirstOrDefaultAsync(m => m.IDLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tLibro == null)
            {
                return Problem("Entity set 'Pra3MMAA.tLibro'  is null.");
            }
            var libro = await _context.tLibro.FindAsync(id);
            if (libro != null)
            {
                _context.tLibro.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return (_context.tLibro?.Any(e => e.IDLibro == id)).GetValueOrDefault();
        }
    }
}

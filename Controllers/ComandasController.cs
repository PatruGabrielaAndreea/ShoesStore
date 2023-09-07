using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoesStore.Data;
using ShoesStore.Models;

namespace ShoesStore.Controllers
{
    public class ComandasController : Controller
    {
        private readonly ShoesStoreContext _context;

        public ComandasController(ShoesStoreContext context)
        {
            _context = context;
        }

        // GET: Comandas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Comanda.ToListAsync());
        }

        // GET: Comandas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda
                .FirstOrDefaultAsync(m => m.Id_Comanda == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // GET: Comandas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comandas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nume,Prenume,Adresa,Tara,Judet,Oras,Telefon,Email,Plata,Id_Produs,Id_User")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comanda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comanda);
        }

        // GET: Comandas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }
            return View(comanda);
        }

        // POST: Comandas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nume,Prenume,Adresa,Tara,Judet,Oras,Telefon,Email,Plata,Id_Produs,Id_User")] Comanda comanda)
        {
            if (id != comanda.Id_Comanda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comanda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandaExists(comanda.Id_Comanda))
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
            return View(comanda);
        }

        // GET: Comandas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda
                .FirstOrDefaultAsync(m => m.Id_Comanda == id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        // POST: Comandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comanda == null)
            {
                return Problem("Entity set 'ShoesStoreContext.Comanda'  is null.");
            }
            var comanda = await _context.Comanda.FindAsync(id);
            if (comanda != null)
            {
                _context.Comanda.Remove(comanda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandaExists(int id)
        {
          return _context.Comanda.Any(e => e.Id_Comanda == id);
        }
    }
}

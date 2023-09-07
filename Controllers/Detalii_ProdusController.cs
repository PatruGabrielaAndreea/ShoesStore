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
    public class Detalii_ProdusController : Controller
    {
        private readonly ShoesStoreContext _context;

        public Detalii_ProdusController(ShoesStoreContext context)
        {
            _context = context;
        }

        // GET: Detalii_Produs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Detalii_Produs.ToListAsync());
        }

        // GET: Detalii_Produs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalii_Produs == null)
            {
                return NotFound();
            }

            var detalii_Produs = await _context.Detalii_Produs
                .FirstOrDefaultAsync(m => m.Id_Detalii == id);
            if (detalii_Produs == null)
            {
                return NotFound();
            }

            return View(detalii_Produs);
        }

        // GET: Detalii_Produs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Detalii_Produs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Detalii,Nume,Marime,Material,Culoare,Gen,Pret,ImageURL,Id_Produs")] Detalii_Produs detalii_Produs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalii_Produs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalii_Produs);
        }

        // GET: Detalii_Produs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalii_Produs == null)
            {
                return NotFound();
            }

            var detalii_Produs = await _context.Detalii_Produs.FindAsync(id);
            if (detalii_Produs == null)
            {
                return NotFound();
            }
            return View(detalii_Produs);
        }

        // POST: Detalii_Produs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Detalii,Nume,Marime,Material,Culoare,Gen,Pret,ImageURL,Id_Produs")] Detalii_Produs detalii_Produs)
        {
            if (id != detalii_Produs.Id_Detalii)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalii_Produs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalii_ProdusExists(detalii_Produs.Id_Detalii))
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
            return View(detalii_Produs);
        }

        // GET: Detalii_Produs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalii_Produs == null)
            {
                return NotFound();
            }

            var detalii_Produs = await _context.Detalii_Produs
                .FirstOrDefaultAsync(m => m.Id_Detalii == id);
            if (detalii_Produs == null)
            {
                return NotFound();
            }

            return View(detalii_Produs);
        }

        // POST: Detalii_Produs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalii_Produs == null)
            {
                return Problem("Entity set 'ShoesStoreContext.Detalii_Produs'  is null.");
            }
            var detalii_Produs = await _context.Detalii_Produs.FindAsync(id);
            if (detalii_Produs != null)
            {
                _context.Detalii_Produs.Remove(detalii_Produs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalii_ProdusExists(int id)
        {
          return _context.Detalii_Produs.Any(e => e.Id_Detalii == id);
        }
    }
}

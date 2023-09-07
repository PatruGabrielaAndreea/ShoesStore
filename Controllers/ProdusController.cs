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
    public class ProdusController : Controller
    {
        private readonly ShoesStoreContext _context;

        public ProdusController(ShoesStoreContext context)
        {
            _context = context;
        }

        // GET: Produs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Produs.ToListAsync());
        }

        // GET: Produs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }

            var produs = await _context.Produs
                .FirstOrDefaultAsync(m => m.Id_Produs == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // GET: Produs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Produs,Nume_Model,Tip,ImageURL,Id_Brand")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produs);
        }

        // GET: Produs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }

            var produs = await _context.Produs.FindAsync(id);
            if (produs == null)
            {
                return NotFound();
            }
            return View(produs);
        }

        // POST: Produs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Produs,Nume_Model,Tip,ImageURL,Id_Brand")] Produs produs)
        {
            if (id != produs.Id_Produs)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdusExists(produs.Id_Produs))
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
            return View(produs);
        }

        // GET: Produs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }

            var produs = await _context.Produs
                .FirstOrDefaultAsync(m => m.Id_Produs == id);
            if (produs == null)
            {
                return NotFound();
            }

            return View(produs);
        }

        // POST: Produs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produs == null)
            {
                return Problem("Entity set 'ShoesStoreContext.Produs'  is null.");
            }
            var produs = await _context.Produs.FindAsync(id);
            if (produs != null)
            {
                _context.Produs.Remove(produs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdusExists(int id)
        {
          return _context.Produs.Any(e => e.Id_Produs == id);
        }
    }
}

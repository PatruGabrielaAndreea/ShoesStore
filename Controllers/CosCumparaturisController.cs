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
    public class CosCumparaturisController : Controller
    {
        private readonly ShoesStoreContext _context;

        public CosCumparaturisController(ShoesStoreContext context)
        {
            _context = context;
        }

        // GET: CosCumparaturis
        public async Task<IActionResult> Index()
        {
              return View(await _context.CosCumparaturi.ToListAsync());
        }

        // GET: CosCumparaturis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CosCumparaturi == null)
            {
                return NotFound();
            }

            var cosCumparaturi = await _context.CosCumparaturi
                .FirstOrDefaultAsync(m => m.Id_Cos == id);
            if (cosCumparaturi == null)
            {
                return NotFound();
            }

            return View(cosCumparaturi);
        }

        // GET: CosCumparaturis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CosCumparaturis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Cos,Cantitate,Id_Produs")] CosCumparaturi cosCumparaturi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cosCumparaturi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cosCumparaturi);
        }

        // GET: CosCumparaturis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CosCumparaturi == null)
            {
                return NotFound();
            }

            var cosCumparaturi = await _context.CosCumparaturi.FindAsync(id);
            if (cosCumparaturi == null)
            {
                return NotFound();
            }
            return View(cosCumparaturi);
        }

        // POST: CosCumparaturis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Cos,Cantitate,Id_Produs")] CosCumparaturi cosCumparaturi)
        {
            if (id != cosCumparaturi.Id_Cos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cosCumparaturi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CosCumparaturiExists(cosCumparaturi.Id_Cos))
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
            return View(cosCumparaturi);
        }

        // GET: CosCumparaturis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CosCumparaturi == null)
            {
                return NotFound();
            }

            var cosCumparaturi = await _context.CosCumparaturi
                .FirstOrDefaultAsync(m => m.Id_Cos == id);
            if (cosCumparaturi == null)
            {
                return NotFound();
            }

            return View(cosCumparaturi);
        }

        // POST: CosCumparaturis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CosCumparaturi == null)
            {
                return Problem("Entity set 'ShoesStoreContext.CosCumparaturi'  is null.");
            }
            var cosCumparaturi = await _context.CosCumparaturi.FindAsync(id);
            if (cosCumparaturi != null)
            {
                _context.CosCumparaturi.Remove(cosCumparaturi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CosCumparaturiExists(int id)
        {
          return _context.CosCumparaturi.Any(e => e.Id_Cos == id);
        }
    }
}

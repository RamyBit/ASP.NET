using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gebraucht_und_Gut.Models;

namespace Gebraucht_und_Gut.Controllers
{
    public class FahrzeugsController : Controller
    {
        private readonly Gebraucht_und_GutContext _context;

        public FahrzeugsController(Gebraucht_und_GutContext context)
        {
            _context = context;
        }

        // GET: Fahrzeugs
        public async Task<IActionResult> Index()
        {
            var gebraucht_und_GutContext = _context.Fahrzeugs.Include(f => f.Re);
            return View(await gebraucht_und_GutContext.ToListAsync());
        }

        // GET: Fahrzeugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fahrzeugs == null)
            {
                return NotFound();
            }

            var fahrzeug = await _context.Fahrzeugs
                .Include(f => f.Re)
                .FirstOrDefaultAsync(m => m.FzId == id);
            if (fahrzeug == null)
            {
                return NotFound();
            }

            return View(fahrzeug);
        }

        // GET: Fahrzeugs/Create
        public IActionResult Create()
        {
            ViewData["ReId"] = new SelectList(_context.Rechnungs, "ReId", "ReId");
            return View();
        }

        // POST: Fahrzeugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FzId,Marke,Typ,Preis,ReId")] Fahrzeug fahrzeug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fahrzeug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReId"] = new SelectList(_context.Rechnungs, "ReId", "ReId", fahrzeug.ReId);
            return View(fahrzeug);
        }

        // GET: Fahrzeugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fahrzeugs == null)
            {
                return NotFound();
            }

            var fahrzeug = await _context.Fahrzeugs.FindAsync(id);
            if (fahrzeug == null)
            {
                return NotFound();
            }
            ViewData["ReId"] = new SelectList(_context.Rechnungs, "ReId", "ReId", fahrzeug.ReId);
            return View(fahrzeug);
        }

        // POST: Fahrzeugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FzId,Marke,Typ,Preis,ReId")] Fahrzeug fahrzeug)
        {
            if (id != fahrzeug.FzId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fahrzeug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FahrzeugExists(fahrzeug.FzId))
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
            ViewData["ReId"] = new SelectList(_context.Rechnungs, "ReId", "ReId", fahrzeug.ReId);
            return View(fahrzeug);
        }

        // GET: Fahrzeugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fahrzeugs == null)
            {
                return NotFound();
            }

            var fahrzeug = await _context.Fahrzeugs
                .Include(f => f.Re)
                .FirstOrDefaultAsync(m => m.FzId == id);
            if (fahrzeug == null)
            {
                return NotFound();
            }

            return View(fahrzeug);
        }

        // POST: Fahrzeugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fahrzeugs == null)
            {
                return Problem("Entity set 'Gebraucht_und_GutContext.Fahrzeugs'  is null.");
            }
            var fahrzeug = await _context.Fahrzeugs.FindAsync(id);
            if (fahrzeug != null)
            {
                _context.Fahrzeugs.Remove(fahrzeug);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FahrzeugExists(int id)
        {
          return _context.Fahrzeugs.Any(e => e.FzId == id);
        }
    }
}

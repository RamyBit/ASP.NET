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
    public class RechnungsController : Controller
    {
        private readonly Gebraucht_und_GutContext _context;

        public RechnungsController(Gebraucht_und_GutContext context)
        {
            _context = context;
        }

        // GET: Rechnungs
        public async Task<IActionResult> Index()
        {
            var gebraucht_und_GutContext = _context.Rechnungs.Include(r => r.Kunde).Include(r => r.Verkaeufer);
            return View(await gebraucht_und_GutContext.ToListAsync());
        }

        // GET: Rechnungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rechnungs == null)
            {
                return NotFound();
            }

            var rechnung = await _context.Rechnungs
                .Include(r => r.Kunde)
                .Include(r => r.Verkaeufer)
                .FirstOrDefaultAsync(m => m.ReId == id);
            if (rechnung == null)
            {
                return NotFound();
            }

            return View(rechnung);
        }

        // GET: Rechnungs/Create
        public IActionResult Create()
        {
            ViewData["KundeId"] = new SelectList(_context.Kundes, "KundeId", "KundeId");
            ViewData["VerkaeuferId"] = new SelectList(_context.Verkaeufers, "VerkaeuferId", "VerkaeuferId");
            return View();
        }

        // POST: Rechnungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReId,Datum,KundeId,VerkaeuferId")] Rechnung rechnung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rechnung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KundeId"] = new SelectList(_context.Kundes, "KundeId", "KundeId", rechnung.KundeId);
            ViewData["VerkaeuferId"] = new SelectList(_context.Verkaeufers, "VerkaeuferId", "VerkaeuferId", rechnung.VerkaeuferId);
            return View(rechnung);
        }

        // GET: Rechnungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rechnungs == null)
            {
                return NotFound();
            }

            var rechnung = await _context.Rechnungs.FindAsync(id);
            if (rechnung == null)
            {
                return NotFound();
            }
            ViewData["KundeId"] = new SelectList(_context.Kundes, "KundeId", "KundeId", rechnung.KundeId);
            ViewData["VerkaeuferId"] = new SelectList(_context.Verkaeufers, "VerkaeuferId", "VerkaeuferId", rechnung.VerkaeuferId);
            return View(rechnung);
        }

        // POST: Rechnungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReId,Datum,KundeId,VerkaeuferId")] Rechnung rechnung)
        {
            if (id != rechnung.ReId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rechnung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RechnungExists(rechnung.ReId))
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
            ViewData["KundeId"] = new SelectList(_context.Kundes, "KundeId", "KundeId", rechnung.KundeId);
            ViewData["VerkaeuferId"] = new SelectList(_context.Verkaeufers, "VerkaeuferId", "VerkaeuferId", rechnung.VerkaeuferId);
            return View(rechnung);
        }

        // GET: Rechnungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rechnungs == null)
            {
                return NotFound();
            }

            var rechnung = await _context.Rechnungs
                .Include(r => r.Kunde)
                .Include(r => r.Verkaeufer)
                .FirstOrDefaultAsync(m => m.ReId == id);
            if (rechnung == null)
            {
                return NotFound();
            }

            return View(rechnung);
        }

        // POST: Rechnungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rechnungs == null)
            {
                return Problem("Entity set 'Gebraucht_und_GutContext.Rechnungs'  is null.");
            }
            var rechnung = await _context.Rechnungs.FindAsync(id);
            if (rechnung != null)
            {
                _context.Rechnungs.Remove(rechnung);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RechnungExists(int id)
        {
          return _context.Rechnungs.Any(e => e.ReId == id);
        }
    }
}

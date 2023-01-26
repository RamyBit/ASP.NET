using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BesuchesController : Controller
    {
        private readonly Pirat_Vertreter_Besuch_ASPContext _context;

        public BesuchesController(Pirat_Vertreter_Besuch_ASPContext context)
        {
            _context = context;
        }

        // GET: Besuches
        public async Task<IActionResult> Index()
        {
            var pirat_Vertreter_Besuch_ASPContext = _context.Besuches.Include(b => b.Consultant).Include(b => b.Kunde);
            return View(await pirat_Vertreter_Besuch_ASPContext.ToListAsync());
        }

        // GET: Besuches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Besuches == null)
            {
                return NotFound();
            }

            var besuch = await _context.Besuches
                .Include(b => b.Consultant)
                .Include(b => b.Kunde)
                .FirstOrDefaultAsync(m => m.BesuchId == id);
            if (besuch == null)
            {
                return NotFound();
            }

            return View(besuch);
        }

        // GET: Besuches/Create
        public IActionResult Create()
        {
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "ConsultantId", "ConsultantId");
            ViewData["KundeId"] = new SelectList(_context.Kundes, "KundeId", "KundeId");
            return View();
        }

        // POST: Besuches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BesuchId,Beschreibung,Datum,ConsultantId,KundeId")] Besuch besuch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(besuch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "ConsultantId", "ConsultantId", besuch.ConsultantId);
            ViewData["KundeId"] = new SelectList(_context.Kundes, "KundeId", "KundeId", besuch.KundeId);
            return View(besuch);
        }

        // GET: Besuches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Besuches == null)
            {
                return NotFound();
            }

            var besuch = await _context.Besuches.FindAsync(id);
            if (besuch == null)
            {
                return NotFound();
            }
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "ConsultantId", "ConsultantId", besuch.ConsultantId);
            ViewData["KundeId"] = new SelectList(_context.Kundes, "KundeId", "KundeId", besuch.KundeId);
            return View(besuch);
        }

        // POST: Besuches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BesuchId,Beschreibung,Datum,ConsultantId,KundeId")] Besuch besuch)
        {
            if (id != besuch.BesuchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(besuch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BesuchExists(besuch.BesuchId))
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
            ViewData["ConsultantId"] = new SelectList(_context.Consultants, "ConsultantId", "ConsultantId", besuch.ConsultantId);
            ViewData["KundeId"] = new SelectList(_context.Kundes, "KundeId", "KundeId", besuch.KundeId);
            return View(besuch);
        }

        // GET: Besuches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Besuches == null)
            {
                return NotFound();
            }

            var besuch = await _context.Besuches
                .Include(b => b.Consultant)
                .Include(b => b.Kunde)
                .FirstOrDefaultAsync(m => m.BesuchId == id);
            if (besuch == null)
            {
                return NotFound();
            }

            return View(besuch);
        }

        // POST: Besuches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Besuches == null)
            {
                return Problem("Entity set 'Pirat_Vertreter_Besuch_ASPContext.Besuches'  is null.");
            }
            var besuch = await _context.Besuches.FindAsync(id);
            if (besuch != null)
            {
                _context.Besuches.Remove(besuch);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BesuchExists(int id)
        {
          return _context.Besuches.Any(e => e.BesuchId == id);
        }
    }
}

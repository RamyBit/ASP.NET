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
    public class ConsultantsController : Controller
    {
        private readonly Pirat_Vertreter_Besuch_ASPContext _context;

        public ConsultantsController(Pirat_Vertreter_Besuch_ASPContext context)
        {
            _context = context;
        }

        // GET: Consultants
        public async Task<IActionResult> Index()
        {
            var pirat_Vertreter_Besuch_ASPContext = _context.Consultants.Include(c => c.Gebiet);
            return View(await pirat_Vertreter_Besuch_ASPContext.ToListAsync());
        }

        // GET: Consultants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consultants == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultants
                .Include(c => c.Gebiet)
                .FirstOrDefaultAsync(m => m.ConsultantId == id);
            if (consultant == null)
            {
                return NotFound();
            }

            return View(consultant);
        }

        // GET: Consultants/Create
        public IActionResult Create()
        {
            ViewData["GebietId"] = new SelectList(_context.Gebiets, "GebietId", "GebietId");
            return View();
        }

        // POST: Consultants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsultantId,Name,GebietId")] Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GebietId"] = new SelectList(_context.Gebiets, "GebietId", "GebietId", consultant.GebietId);
            return View(consultant);
        }

        // GET: Consultants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consultants == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }
            ViewData["GebietId"] = new SelectList(_context.Gebiets, "GebietId", "GebietId", consultant.GebietId);
            return View(consultant);
        }

        // POST: Consultants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsultantId,Name,GebietId")] Consultant consultant)
        {
            if (id != consultant.ConsultantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultantExists(consultant.ConsultantId))
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
            ViewData["GebietId"] = new SelectList(_context.Gebiets, "GebietId", "GebietId", consultant.GebietId);
            return View(consultant);
        }

        // GET: Consultants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consultants == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultants
                .Include(c => c.Gebiet)
                .FirstOrDefaultAsync(m => m.ConsultantId == id);
            if (consultant == null)
            {
                return NotFound();
            }

            return View(consultant);
        }

        // POST: Consultants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consultants == null)
            {
                return Problem("Entity set 'Pirat_Vertreter_Besuch_ASPContext.Consultants'  is null.");
            }
            var consultant = await _context.Consultants.FindAsync(id);
            if (consultant != null)
            {
                _context.Consultants.Remove(consultant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultantExists(int id)
        {
          return _context.Consultants.Any(e => e.ConsultantId == id);
        }
    }
}

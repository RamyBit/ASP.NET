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
    public class GebietsController : Controller
    {
        private readonly Pirat_Vertreter_Besuch_ASPContext _context;

        public GebietsController(Pirat_Vertreter_Besuch_ASPContext context)
        {
            _context = context;
        }

        // GET: Gebiets
        public async Task<IActionResult> Index()
        {
              return View(await _context.Gebiets.ToListAsync());
        }

        // GET: Gebiets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gebiets == null)
            {
                return NotFound();
            }

            var gebiet = await _context.Gebiets
                .FirstOrDefaultAsync(m => m.GebietId == id);
            if (gebiet == null)
            {
                return NotFound();
            }

            return View(gebiet);
        }

        // GET: Gebiets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gebiets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GebietId,Name")] Gebiet gebiet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gebiet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gebiet);
        }

        // GET: Gebiets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gebiets == null)
            {
                return NotFound();
            }

            var gebiet = await _context.Gebiets.FindAsync(id);
            if (gebiet == null)
            {
                return NotFound();
            }
            return View(gebiet);
        }

        // POST: Gebiets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GebietId,Name")] Gebiet gebiet)
        {
            if (id != gebiet.GebietId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gebiet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GebietExists(gebiet.GebietId))
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
            return View(gebiet);
        }

        // GET: Gebiets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gebiets == null)
            {
                return NotFound();
            }

            var gebiet = await _context.Gebiets
                .FirstOrDefaultAsync(m => m.GebietId == id);
            if (gebiet == null)
            {
                return NotFound();
            }

            return View(gebiet);
        }

        // POST: Gebiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gebiets == null)
            {
                return Problem("Entity set 'Pirat_Vertreter_Besuch_ASPContext.Gebiets'  is null.");
            }
            var gebiet = await _context.Gebiets.FindAsync(id);
            if (gebiet != null)
            {
                _context.Gebiets.Remove(gebiet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GebietExists(int id)
        {
          return _context.Gebiets.Any(e => e.GebietId == id);
        }
    }
}

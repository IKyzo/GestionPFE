using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionPFE.Models;

namespace GestionPFE.Controllers
{
    public class SoutenancesController : Controller
    {
        private readonly SoutenanceContext _context;

        public SoutenancesController(SoutenanceContext context)
        {
            _context = context;
        }

        // GET: Soutenances
        public async Task<IActionResult> Index()
        {
            var soutenanceContext = _context.Soutenance.Include(s => s.PFE).Include(s => s.President).Include(s => s.Rapporteur);
            return View(await soutenanceContext.ToListAsync());
        }

        // GET: Soutenances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Soutenance == null)
            {
                return NotFound();
            }

            var soutenance = await _context.Soutenance
                .Include(s => s.PFE)
                .Include(s => s.President)
                .Include(s => s.Rapporteur)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (soutenance == null)
            {
                return NotFound();
            }

            return View(soutenance);
        }

        // GET: Soutenances/Create
        public IActionResult Create()
        {
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "PFEID");
            ViewData["PresidentID"] = new SelectList(_context.Enseignant, "ID", "ID");
            ViewData["RapporteurID"] = new SelectList(_context.Enseignant, "ID", "ID");
            return View();
        }

        // POST: Soutenances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Heure,PFEID,PresidentID,RapporteurID")] Soutenance soutenance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soutenance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "PFEID", soutenance.PFEID);
            ViewData["PresidentID"] = new SelectList(_context.Enseignant, "ID", "ID", soutenance.PresidentID);
            ViewData["RapporteurID"] = new SelectList(_context.Enseignant, "ID", "ID", soutenance.RapporteurID);
            return View(soutenance);
        }

        // GET: Soutenances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Soutenance == null)
            {
                return NotFound();
            }

            var soutenance = await _context.Soutenance.FindAsync(id);
            if (soutenance == null)
            {
                return NotFound();
            }
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "PFEID", soutenance.PFEID);
            ViewData["PresidentID"] = new SelectList(_context.Enseignant, "ID", "ID", soutenance.PresidentID);
            ViewData["RapporteurID"] = new SelectList(_context.Enseignant, "ID", "ID", soutenance.RapporteurID);
            return View(soutenance);
        }

        // POST: Soutenances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Heure,PFEID,PresidentID,RapporteurID")] Soutenance soutenance)
        {
            if (id != soutenance.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soutenance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoutenanceExists(soutenance.ID))
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
            ViewData["PFEID"] = new SelectList(_context.PFE, "PFEID", "PFEID", soutenance.PFEID);
            ViewData["PresidentID"] = new SelectList(_context.Enseignant, "ID", "ID", soutenance.PresidentID);
            ViewData["RapporteurID"] = new SelectList(_context.Enseignant, "ID", "ID", soutenance.RapporteurID);
            return View(soutenance);
        }

        // GET: Soutenances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Soutenance == null)
            {
                return NotFound();
            }

            var soutenance = await _context.Soutenance
                .Include(s => s.PFE)
                .Include(s => s.President)
                .Include(s => s.Rapporteur)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (soutenance == null)
            {
                return NotFound();
            }

            return View(soutenance);
        }

        // POST: Soutenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Soutenance == null)
            {
                return Problem("Entity set 'SoutenanceContext.Soutenance'  is null.");
            }
            var soutenance = await _context.Soutenance.FindAsync(id);
            if (soutenance != null)
            {
                _context.Soutenance.Remove(soutenance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoutenanceExists(int id)
        {
          return (_context.Soutenance?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

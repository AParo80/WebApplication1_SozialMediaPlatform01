using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1_SozialMediaPlatform01.Data;
using WebApplication1_SozialMediaPlatform01.Models;

namespace WebApplication1_SozialMediaPlatform01.Controllers
{
    public class PeepController : Controller
    {
        private readonly WebApplication1_SozialMediaPlatform01Context _context;

        public PeepController(WebApplication1_SozialMediaPlatform01Context context)
        {
            _context = context;
        }

        // GET: Peep
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peep.ToListAsync());
        }

        // GET: Peep/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peep = await _context.Peep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peep == null)
            {
                return NotFound();
            }

            return View(peep);
        }

        // GET: Peep/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peep/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeepWort")] Peep peep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peep);
        }

        // GET: Peep/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peep = await _context.Peep.FindAsync(id);
            if (peep == null)
            {
                return NotFound();
            }
            return View(peep);
        }

        // POST: Peep/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PeepWort")] Peep peep)
        {
            if (id != peep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeepExists(peep.Id))
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
            return View(peep);
        }

        // GET: Peep/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peep = await _context.Peep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peep == null)
            {
                return NotFound();
            }

            return View(peep);
        }

        // POST: Peep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peep = await _context.Peep.FindAsync(id);
            if (peep != null)
            {
                _context.Peep.Remove(peep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeepExists(int id)
        {
            return _context.Peep.Any(e => e.Id == id);
        }

        public async Task<IActionResult> haeufigstePeeps()
        {
            // Die häufigsten Peeps der letzten 24 Stunden
            //List<Peep> peepListe = _context.Peep.Include(n => n.NachrichtListe).ToList();

            List<Peep> peepListeNew = (from p in _context.Peep
                                      where p.NachrichtListe.Any(n => n.PostZeitpunkt > DateTime.Now.AddHours(-24))
                                      orderby p.PeepWort
                                      select p).ToList();



            return View(peepListeNew);
        }
        
    }
}

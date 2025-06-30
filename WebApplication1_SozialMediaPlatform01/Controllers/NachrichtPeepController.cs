using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1_SozialMediaPlatform01.Data;
using WebApplication1_SozialMediaPlatform01.Models;

namespace WebApplication1_SozialMediaPlatform01.Controllers
{
    public class NachrichtPeepController : Controller
    {
        private readonly WebApplication1_SozialMediaPlatform01Context _context;

        public NachrichtPeepController(WebApplication1_SozialMediaPlatform01Context context)
        {
            _context = context;
        }

        // GET: NachrichtPeep
        public async Task<IActionResult> Index()
        {
            var webApplication1_SozialMediaPlatform01Context = _context.NachrichtPeep.Include(n => n.Nachricht).Include(n => n.Peep);
            return View(await webApplication1_SozialMediaPlatform01Context.ToListAsync());
        }

        // GET: NachrichtPeep/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nachrichtPeep = await _context.NachrichtPeep
                .Include(n => n.Nachricht)
                .Include(n => n.Peep)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nachrichtPeep == null)
            {
                return NotFound();
            }

            return View(nachrichtPeep);
        }

        // GET: NachrichtPeep/Create
        public IActionResult Create()
        {
            ViewData["NachrichtId"] = new SelectList(_context.Nachricht, "Id", "Id");
            ViewData["PeepId"] = new SelectList(_context.Peep, "Id", "Id");
            return View();
        }

        // POST: NachrichtPeep/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NachrichtId,PeepId")] NachrichtPeep nachrichtPeep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nachrichtPeep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NachrichtId"] = new SelectList(_context.Nachricht, "Id", "Id", nachrichtPeep.NachrichtId);
            ViewData["PeepId"] = new SelectList(_context.Peep, "Id", "Id", nachrichtPeep.PeepId);
            return View(nachrichtPeep);
        }

        // GET: NachrichtPeep/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nachrichtPeep = await _context.NachrichtPeep.FindAsync(id);
            if (nachrichtPeep == null)
            {
                return NotFound();
            }
            ViewData["NachrichtId"] = new SelectList(_context.Nachricht, "Id", "Id", nachrichtPeep.NachrichtId);
            ViewData["PeepId"] = new SelectList(_context.Peep, "Id", "Id", nachrichtPeep.PeepId);
            return View(nachrichtPeep);
        }

        // POST: NachrichtPeep/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NachrichtId,PeepId")] NachrichtPeep nachrichtPeep)
        {
            if (id != nachrichtPeep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nachrichtPeep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NachrichtPeepExists(nachrichtPeep.Id))
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
            ViewData["NachrichtId"] = new SelectList(_context.Nachricht, "Id", "Id", nachrichtPeep.NachrichtId);
            ViewData["PeepId"] = new SelectList(_context.Peep, "Id", "Id", nachrichtPeep.PeepId);
            return View(nachrichtPeep);
        }

        // GET: NachrichtPeep/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nachrichtPeep = await _context.NachrichtPeep
                .Include(n => n.Nachricht)
                .Include(n => n.Peep)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nachrichtPeep == null)
            {
                return NotFound();
            }

            return View(nachrichtPeep);
        }

        // POST: NachrichtPeep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nachrichtPeep = await _context.NachrichtPeep.FindAsync(id);
            if (nachrichtPeep != null)
            {
                _context.NachrichtPeep.Remove(nachrichtPeep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NachrichtPeepExists(int id)
        {
            return _context.NachrichtPeep.Any(e => e.Id == id);
        }
    }
}

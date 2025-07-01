using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication1_SozialMediaPlatform01.Data;
using WebApplication1_SozialMediaPlatform01.Models;

namespace WebApplication1_SozialMediaPlatform01.Controllers
{
    public class NachrichtController : Controller
    {
        private readonly WebApplication1_SozialMediaPlatform01Context _context;

        public NachrichtController(WebApplication1_SozialMediaPlatform01Context context)
        {
            _context = context;
        }

        // GET: Nachricht
        public async Task<IActionResult> Index()
        {
            var webApplication1_SozialMediaPlatform01Context = _context.Nachricht.Include(n => n.User).Include(x=>x.Like);
            return View(await webApplication1_SozialMediaPlatform01Context.ToListAsync());
        }

        //Seite nicht vorhaneden
        public async Task<IActionResult> BenutzerNachrichtIndex()
        {

            string guid = Request.Cookies["guid"].ToString();
            User user = _context.User.Where(x => x.Guid == guid).FirstOrDefault();

            if (user != null)
            {
                List<Nachricht> meineNachrichten = _context.Nachricht.Where(x =>x.UserId == user.Id).OrderByDescending(x => x.PostZeitpunkt).Take(5).ToList();
                return View(meineNachrichten);
            }

            var webApplication1_SozialMediaPlatform01Context = _context.Nachricht.Include(n => n.User).OrderByDescending(x => x.PostZeitpunkt).Take(5);
            return View(await webApplication1_SozialMediaPlatform01Context.ToListAsync());
        }

        // GET: Nachricht/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nachricht = await _context.Nachricht
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nachricht == null)
            {
                return NotFound();
            }

            return View(nachricht);
        }

        // GET: Nachricht/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password");
            return View();
        }

        // POST: Nachricht/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Post,UserId,PostZeitpunkt")] Nachricht nachricht)
        {
            // Cookie guid wird ausgelesen
            string guid = Request.Cookies["guid"].ToString();
            User user = _context.User.Where(x => x.Guid == guid).FirstOrDefault();
            nachricht.UserId = user.Id;
            nachricht.PostZeitpunkt=DateTime.Now;

            string myPeep = "";

            if (ModelState.IsValid)
            {
                // zwischen > und < muß der peep stehen!
                if (nachricht.Post.Contains('>') && nachricht.Post.Contains('<'))
                {
                    for(int i = nachricht.Post.IndexOf('>'); i <= nachricht.Post.IndexOf('<'); i++)
                    {
                        myPeep += nachricht.Post[i];


                        if (i > 16)
                        {
                            myPeep = "";
                            break;
                        }

                        if(i == nachricht.Post.IndexOf('<'))
                        {
                            Peep peep = new Peep();
                            peep.PeepWort= myPeep;
                            peep.NachrichtListe.Add(nachricht);

                            // Hier kommt Fehlermeldung!-
                            _context.Add(peep);
                            //await _context.SaveChangesAsync();
                        }

                    }
                }

                _context.Add(nachricht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", nachricht.UserId);
            return View(nachricht);
        }

        // GET: Nachricht/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nachricht = await _context.Nachricht.FindAsync(id);
            if (nachricht == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", nachricht.UserId);
            return View(nachricht);
        }

        // POST: Nachricht/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Post,UserId,PostZeitpunkt")] Nachricht nachricht)
        {
            if (id != nachricht.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nachricht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NachrichtExists(nachricht.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Password", nachricht.UserId);
            return View(nachricht);
        }

        // GET: Nachricht/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nachricht = await _context.Nachricht
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nachricht == null)
            {
                return NotFound();
            }

            return View(nachricht);
        }

        // POST: Nachricht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nachricht = await _context.Nachricht.FindAsync(id);
            if (nachricht != null)
            {
                _context.Nachricht.Remove(nachricht);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NachrichtExists(int id)
        {
            return _context.Nachricht.Any(e => e.Id == id);
        }

        //------------- User ermitteln auslager

        public User UserErmitteln()
        {
            string guid = Request.Cookies["guid"].ToString();
            // Person wird anhand des guid ermittelt
            User user = _context.User.Where(x => x.Guid == guid).FirstOrDefault();


            return user;
        }


        //------------- LIKEN
        
        
        public IActionResult Liken(int nachrichtId)
        {
            // User ermitteln dert Liket
            User user = UserErmitteln();
            // Nachricht die geliket wurde
            Nachricht nachricht = _context.Nachricht.Include(x=>x.Like).Where(x=>x.Id == nachrichtId).FirstOrDefault();

            // erstellen neuen Likes
            Like like = new Like();
            like.User=user;
            like.LikeBool = true;
            like.Nachricht=nachricht;

            nachricht.Like.Add(like);

            _context.Add(like);
            _context.Add(nachricht);
            _context.SaveChangesAsync();

            // Wenn geliket dann danke seite
            return View();
        }
    }
}

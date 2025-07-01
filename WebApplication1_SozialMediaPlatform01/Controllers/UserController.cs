using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication1_SozialMediaPlatform01.Data;
using WebApplication1_SozialMediaPlatform01.Models;

namespace WebApplication1_SozialMediaPlatform01.Controllers
{
    public class UserController : Controller
    {
        private readonly WebApplication1_SozialMediaPlatform01Context _context;

        public UserController(WebApplication1_SozialMediaPlatform01Context context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            //return View(await _context.User.ToListAsync());
            return View(_context.User.ToList());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,EMail,Selbstbeschreibung,Password,ConfirmPassword,Guid,IsActive,PasswordHash,PasswordSalt,RegistriertAm")] User user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;
                user.RegistriertAm = DateTime.Now;

                string saltGuid = Guid.NewGuid().ToString();
                user.PasswordSalt = saltGuid;

                byte[] passwordArray = Encoding.UTF8.GetBytes(user.Password);
                byte[] saltByteArray = Encoding.UTF8.GetBytes(saltGuid);
                byte[] combinedByteArray = passwordArray.Concat(saltByteArray).ToArray();

                byte[] hashedByteArray = SHA512.Create().ComputeHash(combinedByteArray);
                string hashString = BitConverter.ToString(hashedByteArray, 0, hashedByteArray.Length);

                user.PasswordHash = hashString;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,EMail,Selbstbeschreibung,Password,ConfirmPassword,Guid,IsActive,PasswordHash,PasswordSalt,RegistriertAm")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.IsActive=true;

                    string saltGuid = Guid.NewGuid().ToString();
                    user.PasswordSalt = saltGuid;

                    byte[] passwordArray = Encoding.UTF8.GetBytes(user.Password);
                    byte[] saltByteArray = Encoding.UTF8.GetBytes(saltGuid);
                    byte[] combinedByteArray = passwordArray.Concat(saltByteArray).ToArray();

                    byte[] hashedByteArray = SHA512.Create().ComputeHash(combinedByteArray);
                    string hashString = BitConverter.ToString(hashedByteArray, 0, hashedByteArray.Length);

                    user.PasswordHash = hashString;

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }


        //-------------------------------------------------------------------------------------------------


        // --------- FEHLER - Handling
        public IActionResult Fehler(string fehlermeldung)
        {
            ViewBag.fehlermeldung = fehlermeldung;
            return View();
        }
        // ----- Login - Logout - Anfang
        public IActionResult LoginForm()
        {
            return View();
        }
        public IActionResult LoginProc(string email, string password)
        {
            // Wenn string ein @ enthält = Email
            // Ansonsten Username

            User user;

            if (email.Contains("@"))
            {
                user = _context.User.Where(x => x.EMail.ToLower() == email.ToLower()).FirstOrDefault();
            }

            else
            {
                user = _context.User.Where(x => x.Username.ToLower() == email.ToLower()).FirstOrDefault();
            }


                

            // Wenn kein Kunde gefunden --> Fehler
            if (user == null)
            {
                string fehlermeldung = $"Diesen Kunden mit der E-Mailadresse bzw Usernamen {email} gibt es NICHT!";
                return RedirectToAction("Fehler", new { fehlermeldung = fehlermeldung });
            }

            // Passwortüberprüfung - Anfang
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);
            byte[] saltByteArray = Encoding.UTF8.GetBytes(user.PasswordSalt);
            byte[] combinedByteArray = passwordArray.Concat(saltByteArray).ToArray();

            byte[] hashedByteArray = SHA512.Create().ComputeHash(combinedByteArray);
            string hashString = BitConverter.ToString(hashedByteArray, 0, hashedByteArray.Length);

            // Wenn passwort falsch --> Fehler
            if (user.PasswordHash != hashString)
            {
                string fehlermeldung = "Passwort FALSCH! Bitte versuchen Sie es erneut!";
                return RedirectToAction("Fehler", new { fehlermeldung = fehlermeldung });
            }

            // Passwortüberprüfung - Ende

            // cookie Setzen 
            Guid guid = Guid.NewGuid();
            user.Guid = guid.ToString();
            Response.Cookies.Append("guid", guid.ToString()); // Cookie wird beim Kunden gesetzt

            _context.SaveChanges(); // Speichern des Guid in die Datenbank
                                    // cookie Setzen 


            //return RedirectToAction("Willkommen", user);
            // User kommt nach Einloggen zu seinen eigegenen chirps und sieht dort seine eigenen 5 stück gepostete Chirps!
            return RedirectToAction("BenutzerNachrichtIndex", "Nachricht");
        }
        public IActionResult Logout()
        {
            // Kunden Finden anhand Cookie
            string guid = Request.Cookies["guid"].ToString();
            User user = _context.User.Where(x => x.Guid == guid).FirstOrDefault();
            if (user != null)
            {
                user.Guid = "";
                _context.SaveChangesAsync();
            }
            Response.Cookies.Delete("guid"); // Löschen des Cookies
            return View();
        }
        public IActionResult Willkommen(User user)
        {
            return View(user);
        }
// ----- Login - Logout - Ende

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using finalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace finalProject.Controllers
{
    public class ProLoginandregsController : Controller
    {
        private readonly ModelContext _context;

        public ProLoginandregsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ProLoginandregs
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ProLoginandregs.Include(p => p.Role);
            return View(await modelContext.ToListAsync());
        }
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(string username, string password)
        {
            const string id = "id";
            const string email = "email";
            var Auth = _context.ProUsers.Where(x => x.Email == username && x.Password == password).SingleOrDefault();
            if (Auth != null)
            {
                switch (Auth.RoleId)
                {
                    case 1:
                        {
                            HttpContext.Session.SetInt32(id, (int)Auth.UserId);
                            HttpContext.Session.SetString(email, (string)Auth.Email);
                            return RedirectToAction("Admin", "ProUsers");
                           

                        }
                    case 2:
                        {
                            HttpContext.Session.SetInt32(id, (int)Auth.UserId);
                            HttpContext.Session.SetString(email, (string)Auth.Email);
                            return RedirectToAction("Accountant", "ProUsers");
                           
                        }
                    case 3:
                        {
                            HttpContext.Session.SetInt32(id, (int)Auth.UserId);
                            HttpContext.Session.SetString(email, (string)Auth.Email);

                            return RedirectToAction("Customer", "ProUsers");

                        }
                    case null:
                        HttpContext.Session.SetInt32(id, (int)Auth.UserId);
                        HttpContext.Session.SetString(email, (string)Auth.Email);
                        return RedirectToAction("Customer", "ProUsers");

                     

                }
               
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

            // GET: ProLoginandregs/Details/5
            public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proLoginandreg = await _context.ProLoginandregs
                .Include(p => p.Role)
                .FirstOrDefaultAsync(m => m.LoginId == id);
            if (proLoginandreg == null)
            {
                return NotFound();
            }

            return View(proLoginandreg);
        }

        // GET: ProLoginandregs/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName");
           
            return View();
        }

        // POST: ProLoginandregs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoginId,FirstName,LastName,UserName,Password,RoleId")] ProLoginandreg proLoginandreg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proLoginandreg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName", proLoginandreg.RoleId);
            return View(proLoginandreg);
        }

        // GET: ProLoginandregs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proLoginandreg = await _context.ProLoginandregs.FindAsync(id);
            if (proLoginandreg == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName", proLoginandreg.RoleId);
            return View(proLoginandreg);
        }

        // POST: ProLoginandregs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("LoginId,FirstName,LastName,UserName,Password,RoleId")] ProLoginandreg proLoginandreg)
        {
            if (id != proLoginandreg.LoginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proLoginandreg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProLoginandregExists(proLoginandreg.LoginId))
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
            ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName", proLoginandreg.RoleId);
            return View(proLoginandreg);
        }

        // GET: ProLoginandregs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proLoginandreg = await _context.ProLoginandregs
                .Include(p => p.Role)
                .FirstOrDefaultAsync(m => m.LoginId == id);
            if (proLoginandreg == null)
            {
                return NotFound();
            }

            return View(proLoginandreg);
        }

        // POST: ProLoginandregs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proLoginandreg = await _context.ProLoginandregs.FindAsync(id);
            _context.ProLoginandregs.Remove(proLoginandreg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProLoginandregExists(decimal id)
        {
            return _context.ProLoginandregs.Any(e => e.LoginId == id);
        }
    }
}

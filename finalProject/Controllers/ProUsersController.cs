using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using finalProject.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace finalProject.Controllers
{
    public class ProUsersController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProUsersController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        
        }

        // GET: ProUsers
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ProUsers.Include(p => p.Role);
            return View(await modelContext.ToListAsync());
        }

        // GET: ProUsers/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proUser = await _context.ProUsers
                .Include(p => p.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (proUser == null)
            {
                return NotFound();
            }

            return View(proUser);
        }

        // GET: ProUsers/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName");
            return View();
        }

        // POST: ProUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,Phone,Email,Password ,ImageFile , Image ,Address,RoleId")] ProUser proUser)
        {
            if (ModelState.IsValid)
            {
                if (proUser.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + proUser.ImageFile.FileName;
                    string extension = Path.GetExtension(proUser.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await proUser.ImageFile.CopyToAsync(fileStream);
                    }
                    proUser.Image = fileName;
                    _context.Add(proUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName", proUser.RoleId);
            return View(proUser);
        }

        // GET: ProUsers/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proUser = await _context.ProUsers.FindAsync(id);
            if (proUser == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName", proUser.RoleId);
            return View(proUser);
        }

        // POST: ProUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("UserId,FirstName,LastName,Phone,Email,Password ,ImageFile , Image ,Address,RoleId")] ProUser proUser)
        {
            if (id != proUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (proUser.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + proUser.ImageFile.FileName;
                        string extension = Path.GetExtension(proUser.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await proUser.ImageFile.CopyToAsync(fileStream);
                        }
                        proUser.Image = fileName;
                        _context.Update(proUser);
                        await _context.SaveChangesAsync();
                    }
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!ProUserExists(proUser.UserId))
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
            ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName", proUser.RoleId);
            return View(proUser);
        }

        // GET: ProUsers/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proUser = await _context.ProUsers
                .Include(p => p.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (proUser == null)
            {
                return NotFound();
            }

            return View(proUser);
        }

        // POST: ProUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proUser = await _context.ProUsers.FindAsync(id);
            _context.ProUsers.Remove(proUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProUserExists(decimal id)
        {
            
            return _context.ProUsers.Any(e => e.UserId == id);
        }

        public IActionResult Customer()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);

            string phone = "phone";
            ViewBag.phone = HttpContext.Session.GetInt32(phone);

            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            return View();
    
        }

        public IActionResult Admin()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            ;
            string phone = "phone";
            ViewBag.phone = HttpContext.Session.GetInt32(phone);

            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            return View();
        }
        public IActionResult Accountant()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            ;
            string phone = "phone";
            ViewBag.phone = HttpContext.Session.GetInt32(phone);
            
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            return View();
        }

       
        public async Task<IActionResult> AccountantView()
        {
            var modelContext = _context.ProUsers.Include(p => p.Role);
            return View(await modelContext.ToListAsync());
        }


        public IActionResult register()
        {
            //ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName");
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> register([Bind("UserId,FirstName,LastName,Phone,Email,Password ,ImageFile , Image ,Address")] ProUser proUser)
        {
            if (ModelState.IsValid)
            {
                if (proUser.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + proUser.ImageFile.FileName;
                    string extension = Path.GetExtension(proUser.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await proUser.ImageFile.CopyToAsync(fileStream);
                    }
                    proUser.Image = fileName;
                    _context.Add(proUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("login","proLoginandregs");

                }
                else if (proUser.Email != null)
                {

                    _context.Add(proUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("login", "proLoginandregs");
                }
            }
            //ViewData["RoleId"] = new SelectList(_context.ProRoles, "RoleId", "RoleName", proUser.RoleId);
            return View("register");
        }

    }
}

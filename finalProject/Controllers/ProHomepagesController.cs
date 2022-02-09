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
    public class ProHomepagesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProHomepagesController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = _hostEnvironment;
        }

        // GET: ProHomepages
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ProHomepages.Include(p => p.About).Include(p => p.Contact);
            return View(await modelContext.ToListAsync());
        }

        // GET: ProHomepages/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proHomepage = await _context.ProHomepages
                .Include(p => p.About)
                .Include(p => p.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proHomepage == null)
            {
                return NotFound();
            }

            return View(proHomepage);
        }

        // GET: ProHomepages/Create
        public IActionResult Create()
        {
            ViewData["AboutId"] = new SelectList(_context.ProAbouts, "AboutId", "AboutId");
            ViewData["ContactId"] = new SelectList(_context.ProContacts, "ContactId", "ContactId");
            return View();
        }

        // POST: ProHomepages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContactId,AboutId,Image,ImageFile")] ProHomepage proHomepage)
        {
            if (ModelState.IsValid)
            {

                if (proHomepage.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + proHomepage.ImageFile.FileName;
                    string extension = Path.GetExtension(proHomepage.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await proHomepage.ImageFile.CopyToAsync(fileStream);
                    }
                    proHomepage.Image = fileName;
                    _context.Add(proHomepage);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
               
            }
            ViewData["AboutId"] = new SelectList(_context.ProAbouts, "AboutId", "AboutId", proHomepage.AboutId);
            ViewData["ContactId"] = new SelectList(_context.ProContacts, "ContactId", "ContactId", proHomepage.ContactId);
            return View(proHomepage);
        }

        // GET: ProHomepages/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proHomepage = await _context.ProHomepages.FindAsync(id);
            if (proHomepage == null)
            {
                return NotFound();
            }
            ViewData["AboutId"] = new SelectList(_context.ProAbouts, "AboutId", "AboutId", proHomepage.AboutId);
            ViewData["ContactId"] = new SelectList(_context.ProContacts, "ContactId", "ContactId", proHomepage.ContactId);
            return View(proHomepage);
        }

        // POST: ProHomepages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,ContactId,Image,AboutId")] ProHomepage proHomepage)
        {
            if (id != proHomepage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proHomepage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProHomepageExists(proHomepage.Id))
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
            ViewData["AboutId"] = new SelectList(_context.ProAbouts, "AboutId", "AboutId", proHomepage.AboutId);
            ViewData["ContactId"] = new SelectList(_context.ProContacts, "ContactId", "ContactId", proHomepage.ContactId);
            return View(proHomepage);
        }

        // GET: ProHomepages/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proHomepage = await _context.ProHomepages
                .Include(p => p.About)
                .Include(p => p.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proHomepage == null)
            {
                return NotFound();
            }

            return View(proHomepage);
        }

        // POST: ProHomepages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proHomepage = await _context.ProHomepages.FindAsync(id);
            _context.ProHomepages.Remove(proHomepage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProHomepageExists(decimal id)
        {
            return _context.ProHomepages.Any(e => e.Id == id);
        }

        public IActionResult homeCustomer()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            var result1 = _context.ProCategories.ToList();
            var result2 = _context.ProProducts.ToList();


            var result3 = _context.ProHomepages.ToList();
            var model = new Tuple<IEnumerable<finalProject.Models.ProCategory>, IEnumerable<finalProject.Models.ProProduct>, IEnumerable<finalProject.Models.ProHomepage> >(result1, result2,result3);
            return View(model);
        }
    }
}

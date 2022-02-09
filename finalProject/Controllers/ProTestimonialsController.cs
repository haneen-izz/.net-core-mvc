using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using finalProject.Models;
using Microsoft.AspNetCore.Http;

namespace finalProject.Controllers
{
    public class ProTestimonialsController : Controller
    {
        private readonly ModelContext _context;

        public ProTestimonialsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ProTestimonials
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ProTestimonials.Include(p => p.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: ProTestimonials/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proTestimonial = await _context.ProTestimonials
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.TestimonialId == id);
            if (proTestimonial == null)
            {
                return NotFound();
            }

            return View(proTestimonial);
        }

        // GET: ProTestimonials/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId");
            return View();
        }

        // POST: ProTestimonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestimonialId,TestimonialText,UserId")] ProTestimonial proTestimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proTestimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proTestimonial.UserId);
            return View(proTestimonial);
        }

        // GET: ProTestimonials/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proTestimonial = await _context.ProTestimonials.FindAsync(id);
            if (proTestimonial == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proTestimonial.UserId);
            return View(proTestimonial);
        }

        // POST: ProTestimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("TestimonialId,TestimonialText,UserId")] ProTestimonial proTestimonial)
        {
            if (id != proTestimonial.TestimonialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proTestimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProTestimonialExists(proTestimonial.TestimonialId))
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
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proTestimonial.UserId);
            return View(proTestimonial);
        }

        // GET: ProTestimonials/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proTestimonial = await _context.ProTestimonials
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.TestimonialId == id);
            if (proTestimonial == null)
            {
                return NotFound();
            }

            return View(proTestimonial);
        }

        // POST: ProTestimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proTestimonial = await _context.ProTestimonials.FindAsync(id);
            _context.ProTestimonials.Remove(proTestimonial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProTestimonialExists(decimal id)
        {
            return _context.ProTestimonials.Any(e => e.TestimonialId == id);
        }

        public IActionResult userTestimonial()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> userTestimonial([Bind("TestimonialId,TestimonialText,UserId")] ProTestimonial proTestimonial)
        {

            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
;
            if (ModelState.IsValid)
            {
                _context.Add(proTestimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction("homeCustomer", "proHomepages");
            }
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proTestimonial.UserId);
            return View(proTestimonial);
        }














    }
}

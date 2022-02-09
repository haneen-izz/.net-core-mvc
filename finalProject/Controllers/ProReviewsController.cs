using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using finalProject.Models;

namespace finalProject.Controllers
{
    public class ProReviewsController : Controller
    {
        private readonly ModelContext _context;

        public ProReviewsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ProReviews
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ProReviews.Include(p => p.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: ProReviews/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proReview = await _context.ProReviews
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (proReview == null)
            {
                return NotFound();
            }

            return View(proReview);
        }

        // GET: ProReviews/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId");
            return View();
        }

        // POST: ProReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,UserId,Rating,Message")] ProReview proReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proReview.UserId);
            return View(proReview);
        }

        // GET: ProReviews/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proReview = await _context.ProReviews.FindAsync(id);
            if (proReview == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proReview.UserId);
            return View(proReview);
        }

        // POST: ProReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ReviewId,UserId,Rating,Message")] ProReview proReview)
        {
            if (id != proReview.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProReviewExists(proReview.ReviewId))
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
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proReview.UserId);
            return View(proReview);
        }

        // GET: ProReviews/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proReview = await _context.ProReviews
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (proReview == null)
            {
                return NotFound();
            }

            return View(proReview);
        }

        // POST: ProReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proReview = await _context.ProReviews.FindAsync(id);
            _context.ProReviews.Remove(proReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProReviewExists(decimal id)
        {
            return _context.ProReviews.Any(e => e.ReviewId == id);
        }
    }
}

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
    public class ProAboutsController : Controller
    {
        private readonly ModelContext _context;

        public ProAboutsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ProAbouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProAbouts.ToListAsync());
        }

        // GET: ProAbouts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proAbout = await _context.ProAbouts
                .FirstOrDefaultAsync(m => m.AboutId == id);
            if (proAbout == null)
            {
                return NotFound();
            }

            return View(proAbout);
        }

        // GET: ProAbouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProAbouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutId,Text2")] ProAbout proAbout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proAbout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proAbout);
        }

        // GET: ProAbouts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proAbout = await _context.ProAbouts.FindAsync(id);
            if (proAbout == null)
            {
                return NotFound();
            }
            return View(proAbout);
        }

        // POST: ProAbouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("AboutId,Text2")] ProAbout proAbout)
        {
            if (id != proAbout.AboutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proAbout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProAboutExists(proAbout.AboutId))
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
            return View(proAbout);
        }

        // GET: ProAbouts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proAbout = await _context.ProAbouts
                .FirstOrDefaultAsync(m => m.AboutId == id);
            if (proAbout == null)
            {
                return NotFound();
            }

            return View(proAbout);
        }

        // POST: ProAbouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proAbout = await _context.ProAbouts.FindAsync(id);
            _context.ProAbouts.Remove(proAbout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProAboutExists(decimal id)
        {
            return _context.ProAbouts.Any(e => e.AboutId == id);
        }
        public IActionResult AboutCustomer()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            return View(_context.ProAbouts.ToList());
        }
    }
}
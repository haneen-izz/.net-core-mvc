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
    public class ProContactsController : Controller
    {
        private readonly ModelContext _context;

        public ProContactsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ProContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProContacts.ToListAsync());
        }

        // GET: ProContacts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proContact = await _context.ProContacts
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (proContact == null)
            {
                return NotFound();
            }

            return View(proContact);
        }

        // GET: ProContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,Name,Age,Email,Phone")] ProContact proContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proContact);
        }

        // GET: ProContacts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proContact = await _context.ProContacts.FindAsync(id);
            if (proContact == null)
            {
                return NotFound();
            }
            return View(proContact);
        }

        // POST: ProContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ContactId,Name,Age,Email,Phone")] ProContact proContact)
        {
            if (id != proContact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProContactExists(proContact.ContactId))
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
            return View(proContact);
        }

        // GET: ProContacts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proContact = await _context.ProContacts
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (proContact == null)
            {
                return NotFound();
            }

            return View(proContact);
        }

        // POST: ProContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proContact = await _context.ProContacts.FindAsync(id);
            _context.ProContacts.Remove(proContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProContactExists(decimal id)
        {
            return _context.ProContacts.Any(e => e.ContactId == id);
        }
        public IActionResult customerContact()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> customerContact([Bind("ContactId,Name,Age,Email,Phone")] ProContact proContact)
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            if (ModelState.IsValid)
            {
                if (proContact.Email != null)
                {

                    _context.Add(proContact);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("homeCustomer", "proHomepages");
                }
            }
            return View(); 
        }




    }
}

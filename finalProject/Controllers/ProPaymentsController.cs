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
    public class ProPaymentsController : Controller
    {
        private readonly ModelContext _context;

        public ProPaymentsController(ModelContext context)
        {
            _context = context;
        }

        // GET: ProPayments
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ProPayments.Include(p => p.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: ProPayments/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proPayment = await _context.ProPayments
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (proPayment == null)
            {
                return NotFound();
            }

            return View(proPayment);
        }

        // GET: ProPayments/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId");
            return View();
        }

        // POST: ProPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,CardName,CardNum,Amount,CardExp,UserId")] ProPayment proPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proPayment.UserId);
            return View(proPayment);
        }

        // GET: ProPayments/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proPayment = await _context.ProPayments.FindAsync(id);
            if (proPayment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proPayment.UserId);
            return View(proPayment);
        }

        // POST: ProPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("PaymentId,CardName,CardNum,Amount,CardExp,UserId")] ProPayment proPayment)
        {
            if (id != proPayment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProPaymentExists(proPayment.PaymentId))
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
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proPayment.UserId);
            return View(proPayment);
        }

        // GET: ProPayments/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proPayment = await _context.ProPayments
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (proPayment == null)
            {
                return NotFound();
            }

            return View(proPayment);
        }

        // POST: ProPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proPayment = await _context.ProPayments.FindAsync(id);
            _context.ProPayments.Remove(proPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProPaymentExists(decimal id)
        {
            return _context.ProPayments.Any(e => e.PaymentId == id);
        }
      public IActionResult customerPayement()
        {
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId");

            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> customerPayement([Bind("PaymentId, CardName, CardNum, Amount, CardExp, UserId")] ProPayment proPayment)
        {

            if (ModelState.IsValid)
            {
                if (proPayment.CardNum != null)
                {
                    _context.Add(proPayment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("homeCustomer", "proHomepages");
                }
            }

            return View();
        }

        public IActionResult payementView(int id)
        {
            string d = "id";
            ViewBag.session = HttpContext.Session.GetInt32(d);
            var payement = _context.ProPayments.Where(x => x.UserId == id).ToList();
            return View(payement);
        }

        public async Task<IActionResult> payementAccountant()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            var modelContext = _context.ProPayments.Include(p => p.User);
            return View(await modelContext.ToListAsync());
        }




    }
}

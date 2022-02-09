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
    public class ProOrdersController : Controller
    {
        private readonly ModelContext _context;

        public ProOrdersController(ModelContext context)
        {
            _context = context;
        }

        // GET: ProOrders
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ProOrders.Include(p => p.User);
            return View(await modelContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(DateTime firstDate, DateTime secondDate)
        {
            var ord = _context.ProOrders.Where(x => x.OrdersDate > firstDate && x.OrdersDate < secondDate).ToList();
            return View(ord);
        }
      




        // GET: ProOrders/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proOrder = await _context.ProOrders
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (proOrder == null)
            {
                return NotFound();
            }

            return View(proOrder);
        }

        // GET: ProOrders/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId");
            return View();
        }

        // POST: ProOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserId,Quantity,ProductId,Sales,OrdersDate")] ProOrder proOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proOrder.UserId);
            return View(proOrder);
        }

        // GET: ProOrders/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proOrder = await _context.ProOrders.FindAsync(id);
            if (proOrder == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proOrder.UserId);
            return View(proOrder);
        }

        // POST: ProOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("OrderId,UserId,Quantity,ProductId,Sales,OrdersDate")] ProOrder proOrder)
        {
            if (id != proOrder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProOrderExists(proOrder.OrderId))
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
            ViewData["UserId"] = new SelectList(_context.ProUsers, "UserId", "UserId", proOrder.UserId);
            return View(proOrder);
        }

        // GET: ProOrders/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proOrder = await _context.ProOrders
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (proOrder == null)
            {
                return NotFound();
            }

            return View(proOrder);
        }

        // POST: ProOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proOrder = await _context.ProOrders.FindAsync(id);
            _context.ProOrders.Remove(proOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProOrderExists(decimal id)
        {
            return _context.ProOrders.Any(e => e.OrderId == id);
        }
        public IActionResult AccountantView()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AccountantView(DateTime firstDate , DateTime secondDate)
        {
            //string id = "id";
            //ViewBag.session = HttpContext.Session.GetInt32(id);
            var ord = _context.ProOrders.Where(x => x.OrdersDate > firstDate && x.OrdersDate < secondDate).ToList();
            return View();
        }



    }
}

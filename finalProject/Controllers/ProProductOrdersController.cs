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
    public class ProProductOrdersController : Controller
    {
        private readonly ModelContext _context;

        public ProProductOrdersController(ModelContext context)
        {
            _context = context;
        }

        // GET: ProProductOrders
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ProProductOrders.Include(p => p.Order).Include(p => p.Product);
            return View(await modelContext.ToListAsync());
        }

        // GET: ProProductOrders/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proProductOrder = await _context.ProProductOrders
                .Include(p => p.Order)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proProductOrder == null)
            {
                return NotFound();
            }

            return View(proProductOrder);
        }

        // GET: ProProductOrders/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.ProOrders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.ProProducts, "ProductId", "ProductId");
            return View();
        }

        // POST: ProProductOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,OrderId")] ProProductOrder proProductOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proProductOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.ProOrders, "OrderId", "OrderId", proProductOrder.OrderId);
            ViewData["ProductId"] = new SelectList(_context.ProProducts, "ProductId", "ProductId", proProductOrder.ProductId);
            return View(proProductOrder);
        }

        // GET: ProProductOrders/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proProductOrder = await _context.ProProductOrders.FindAsync(id);
            if (proProductOrder == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.ProOrders, "OrderId", "OrderId", proProductOrder.OrderId);
            ViewData["ProductId"] = new SelectList(_context.ProProducts, "ProductId", "ProductId", proProductOrder.ProductId);
            return View(proProductOrder);
        }

        // POST: ProProductOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,ProductId,OrderId")] ProProductOrder proProductOrder)
        {
            if (id != proProductOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proProductOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProProductOrderExists(proProductOrder.Id))
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
            ViewData["OrderId"] = new SelectList(_context.ProOrders, "OrderId", "OrderId", proProductOrder.OrderId);
            ViewData["ProductId"] = new SelectList(_context.ProProducts, "ProductId", "ProductId", proProductOrder.ProductId);
            return View(proProductOrder);
        }

        // GET: ProProductOrders/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proProductOrder = await _context.ProProductOrders
                .Include(p => p.Order)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proProductOrder == null)
            {
                return NotFound();
            }

            return View(proProductOrder);
        }

        // POST: ProProductOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proProductOrder = await _context.ProProductOrders.FindAsync(id);
            _context.ProProductOrders.Remove(proProductOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProProductOrderExists(decimal id)
        {
            return _context.ProProductOrders.Any(e => e.Id == id);
        }
    }
}

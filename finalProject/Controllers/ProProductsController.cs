using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using finalProject.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace finalProject.Controllers
{
    public class ProProductsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProProductsController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: ProProducts
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ProProducts.Include(p => p.Category);
            return View(await modelContext.ToListAsync());


            //var pro1 = _context.ProProducts.Where(x => x.CategoryId == id).ToList();
           
        }

        // GET: ProProducts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proProduct = await _context.ProProducts
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (proProduct == null)
            {
                return NotFound();
            }

            return View(proProduct);
        }

        // GET: ProProducts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.ProCategories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: ProProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Quantity,Sale,Cost,Image,ImageFile ,CategoryId")] ProProduct proProduct)
        {
            if (ModelState.IsValid)
            {
                if (proProduct.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + proProduct.ImageFile.FileName;
                    string extension = Path.GetExtension(proProduct.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await proProduct.ImageFile.CopyToAsync(fileStream);
                    }
                    proProduct.Image = fileName;
                    _context.Add(proProduct);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CategoryId"] = new SelectList(_context.ProCategories, "CategoryId", "CategoryId", proProduct.CategoryId);
            return View(proProduct);
        }

        // GET: ProProducts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proProduct = await _context.ProProducts.FindAsync(id);
            if (proProduct == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.ProCategories, "CategoryId", "CategoryId", proProduct.CategoryId);
            return View(proProduct);
        }

        // POST: ProProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ProductId,ProductName,Quantity,Sale,Cost,Image,ImageFile,CategoryId")] ProProduct proProduct)
        {
            if (id != proProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (proProduct.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + proProduct.ImageFile.FileName;
                        string extension = Path.GetExtension(proProduct.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await proProduct.ImageFile.CopyToAsync(fileStream);
                        }
                        proProduct.Image = fileName;
                        _context.Update(proProduct);
                        await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProProductExists(proProduct.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.ProCategories, "CategoryId", "CategoryId", proProduct.CategoryId);
            return View(proProduct);
        }

        // GET: ProProducts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proProduct = await _context.ProProducts
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (proProduct == null)
            {
                return NotFound();
            }

            return View(proProduct);
        }

        // POST: ProProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proProduct = await _context.ProProducts.FindAsync(id);
            _context.ProProducts.Remove(proProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProProductExists(decimal id)
        {
            return _context.ProProducts.Any(e => e.ProductId == id);
        }


        public IActionResult customerPro()
        {
            //var pro = _context.ProProducts.Where(x => x.CategoryId == id).ToList();
            //return View(pro);
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            var modelContext = _context.ProProducts.ToList();   
            return View(modelContext);

            //return View(await modelContext.ToListAsync());
            //var pro1 = _context.ProProducts.Where(c => c.CategoryId == id).ToList();
            //return View(pro1);
        }

        public IActionResult ProCat(int id)
        {
            string d = "id";
            ViewBag.session = HttpContext.Session.GetInt32(d);
            var pro = _context.ProProducts.Where(x => x.CategoryId == id).ToList();
            return View(pro);
            //var modelContext = _context.ProProducts.Include(p => p.Category);
            //return View(modelContext);

            //return View(await modelContext.ToListAsync());
            //var pro1 = _context.ProProducts.Where(c => c.CategoryId == id).ToList();
            //return View(pro1);
        }


    }
}

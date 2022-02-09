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
    public class ProCategoriesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProCategoriesController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = _hostEnvironment;
        }

        // GET: ProCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProCategories.ToListAsync());
        }

       
        // GET: ProCategories/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proCategory = await _context.ProCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (proCategory == null)
            {
                return NotFound();
            }

            return View(proCategory);
        }

        // GET: ProCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,ImageFile,Image")] ProCategory proCategory)
        {
            if (ModelState.IsValid)
            {

                if (proCategory.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + proCategory.ImageFile.FileName;
                    string extension = Path.GetExtension(proCategory.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await proCategory.ImageFile.CopyToAsync(fileStream);
                    }
                    proCategory.Image = fileName;
                    _context.Add(proCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(proCategory);
        }

        // GET: ProCategories/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proCategory = await _context.ProCategories.FindAsync(id);
            if (proCategory == null)
            {
                return NotFound();
            }
            return View(proCategory);
        }

        // POST: ProCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CategoryId,CategoryName,ImageFile,Image")] ProCategory proCategory)
        {
            if (id != proCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (proCategory.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + proCategory.ImageFile.FileName;
                        string extension = Path.GetExtension(proCategory.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await proCategory.ImageFile.CopyToAsync(fileStream);
                        }
                        proCategory.Image = fileName;
                        //_context.Add(proCategory);
                        _context.Update(proCategory);
                        await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                    }
                }
            //return View(proCategory);

                //_context.Update(proCategory);
                //    await _context.SaveChangesAsync();
                
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProCategoryExists(proCategory.CategoryId))
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
            return View(proCategory);
        }

        // GET: ProCategories/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proCategory = await _context.ProCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (proCategory == null)
            {
                return NotFound();
            }

            return View(proCategory);
        }

        // POST: ProCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proCategory = await _context.ProCategories.FindAsync(id);
            _context.ProCategories.Remove(proCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProCategoryExists(decimal id)
        {
            return _context.ProCategories.Any(e => e.CategoryId == id);
        }
        public IActionResult CustomerCat()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            var result = _context.ProCategories.ToList();
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomerCat(string name)
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);

            var result = _context.ProCategories.Where(s => s.CategoryName.Contains(name));
            return View(result);



            //var pro = _context.ProCategories.Where(x => x.CategoryName == name).ToList();
            //return View(pro);
        }
    }
}

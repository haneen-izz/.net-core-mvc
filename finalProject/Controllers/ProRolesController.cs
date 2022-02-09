using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using finalProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace finalProject.Controllers
{
    public class ProRolesController : Controller
    {
        private readonly ModelContext _context;

        public ProRolesController(ModelContext context)
        {
            _context = context;
        }

        // GET: ProRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProRoles.ToListAsync());
           
        }

        

        // GET: ProRoles/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var proRole = await _context.ProRoles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (proRole == null)
            {
                return NotFound();
            }

            return View(proRole);
        }

        // GET: ProRoles/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: ProRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName")] ProRole proRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proRole);
        }

        // GET: ProRoles/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proRole = await _context.ProRoles.FindAsync(id);
            if (proRole == null)
            {
                return NotFound();
            }
            return View(proRole);
        }

        // POST: ProRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("RoleId,RoleName")] ProRole proRole)
        {
            if (id != proRole.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProRoleExists(proRole.RoleId))
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
            return View(proRole);
        }

        // GET: ProRoles/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proRole = await _context.ProRoles
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (proRole == null)
            {
                return NotFound();
            }

            return View(proRole);
        }

        // POST: ProRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var proRole = await _context.ProRoles.FindAsync(id);
            _context.ProRoles.Remove(proRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProRoleExists(decimal id)
        {
            return _context.ProRoles.Any(e => e.RoleId == id);
        }
    }
}

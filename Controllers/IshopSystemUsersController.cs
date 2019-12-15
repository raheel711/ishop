using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ishop.Models;

namespace ishop.Controllers
{
    public class IshopSystemUsersController : Controller
    {
        private readonly ishopContext _context;

        public IshopSystemUsersController(ishopContext context)
        {
            _context = context;
        }

        // GET: IshopSystemUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.IshopSystemUser.ToListAsync());
        }

        // GET: IshopSystemUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopSystemUser = await _context.IshopSystemUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopSystemUser == null)
            {
                return NotFound();
            }

            return View(ishopSystemUser);
        }

        // GET: IshopSystemUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IshopSystemUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DisplayName,SuUsername,SuPassword,SuStatus,SuEmail,SuProfilePic,SuRole,AddedDate,AddedBy,Extra")] IshopSystemUser ishopSystemUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ishopSystemUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ishopSystemUser);
        }

        // GET: IshopSystemUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopSystemUser = await _context.IshopSystemUser.FindAsync(id);
            if (ishopSystemUser == null)
            {
                return NotFound();
            }
            return View(ishopSystemUser);
        }

        // POST: IshopSystemUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DisplayName,SuUsername,SuPassword,SuStatus,SuEmail,SuProfilePic,SuRole,AddedDate,AddedBy,Extra")] IshopSystemUser ishopSystemUser)
        {
            if (id != ishopSystemUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ishopSystemUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IshopSystemUserExists(ishopSystemUser.Id))
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
            return View(ishopSystemUser);
        }

        // GET: IshopSystemUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopSystemUser = await _context.IshopSystemUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopSystemUser == null)
            {
                return NotFound();
            }

            return View(ishopSystemUser);
        }

        // POST: IshopSystemUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ishopSystemUser = await _context.IshopSystemUser.FindAsync(id);
            _context.IshopSystemUser.Remove(ishopSystemUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IshopSystemUserExists(int id)
        {
            return _context.IshopSystemUser.Any(e => e.Id == id);
        }
    }
}

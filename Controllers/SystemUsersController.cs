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
    public class SystemUsersController : Controller
    {
        private readonly ishopContext _context;

        public SystemUsersController(ishopContext context)
        {
            _context = context;
        }

        // GET: SystemUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.SystemUser.ToListAsync());
        }

        // GET: SystemUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemUser = await _context.SystemUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemUser == null)
            {
                return NotFound();
            }

            return View(systemUser);
        }

        // GET: SystemUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DisplayName,SuUsername,SuPassword,SuStatus,SuProfilePic,SuRole,AddedDate,AddedBy,Extra,SuEmail")] SystemUser systemUser)
        {
            if (ModelState.IsValid)
            {

        


                _context.Add(systemUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemUser);
        }

        // GET: SystemUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemUser = await _context.SystemUser.FindAsync(id);
            if (systemUser == null)
            {
                return NotFound();
            }
            return View(systemUser);
        }

        // POST: SystemUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DisplayName,SuUsername,SuPassword,SuStatus,SuProfilePic,SuRole,AddedDate,AddedBy,Extra")] SystemUser systemUser)
        {
            if (id != systemUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemUserExists(systemUser.Id))
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
            return View(systemUser);
        }

        // GET: SystemUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemUser = await _context.SystemUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemUser == null)
            {
                return NotFound();
            }

            return View(systemUser);
        }

        // POST: SystemUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemUser = await _context.SystemUser.FindAsync(id);
            _context.SystemUser.Remove(systemUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemUserExists(int id)
        {
            return _context.SystemUser.Any(e => e.Id == id);
        }

        // GET: SystemUsers/Login
        public IActionResult Login()
        {

            return View();
        }

        // GET: SystemUsers/Register
        public IActionResult Register()
        {

            return View();
        }

        // GET: SystemUsers/ForgetPassword
        public IActionResult ForgetPassword()
        {

            return View();
        }


        //public string LoginCheck(string SuUsername, string SuPassword)
        //{
        //    if (SuUsername != "" || SuPassword != "")
        //    {
        //        SystemUser su = _context.SystemUser.FirstOrDefault(s => s.SuUsername == SuUsername && s.SuPassword == SuPassword);

        //        if (su != null)
        //        {
        //            if (su.SuStatus == "active")
        //            {
        //                HttpContext.Session.SetString("SessionUsername", su.SuUsername);
        //                HttpContext.Session.SetString("SessionBranchId", su.BranchId.ToString());

        //                HttpContext.Session.SetString("SessionUserRole", su.SuRole);

        //                //role id: WHat user can perform.. It'll get data from role_permissions
        //                Role r = ORM.Role.FirstOrDefault(rs => rs.RoleName == su.SuRole);
        //                HttpContext.Session.SetString("SessionUserRoleID", r.Id.ToString());


        //                // I want this in loop so i can retrive each row data
        //                ORM.RolePermission.Where(rps => rps.RoleId == r.Id).ToList();



        //                TempData["added_date"] = su.SuAddedDate;

        //                return "true";
        //            }
        //            else { return "inactive"; }
        //        }
        //        else
        //        {
        //            return "false";
        //        }
        //    }
        //    else
        //    {
        //        return "false";
        //    }

        //}



    }
}

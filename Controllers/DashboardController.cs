using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ishop.Helpers;
using ishop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ishop.Controllers
{
    public class DashboardController : Controller
    {


        private readonly ishopContext _context;

        public DashboardController(ishopContext context)
        {
            _context = context;
        }

        Helper Hlp = new Helper();


        //How to use this function in Helper folders
        public bool AuthenticateUser()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionUsername")))
            {
                return false;
            }

            ViewBag.totalCategories = _context.Category.ToList().Count();
            ViewBag.totalProducts = _context.Product.ToList().Count();
            ViewBag.activeSU = _context.SystemUser.Where(abc=>abc.SuStatus=="active").ToList().Count();
            ViewBag.totalSU = _context.SystemUser.ToList().Count();

            return true;
        }

        public IActionResult Index()
        {
            

            if (AuthenticateUser())
            {
               
                return View();
            }
            else
            {
                return RedirectToAction("login", "SystemUsers");
            }


           
        }
    }
}
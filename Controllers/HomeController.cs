using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ishop.Models;
using Microsoft.AspNetCore.Http;
using ishop.Helpers;

namespace ishop.Controllers
{
    public class HomeController : Controller
    {

        private readonly ishopContext _context;

        public HomeController(ishopContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            if (AuthenticateUser()) {
                return View();
            } else {
                return RedirectToAction(nameof(Login));
            }

        }

        
        //How to use this function in Helper folders
        public bool AuthenticateUser()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionUsername")))
            {
                return false;
            }
            ViewBag.totalCategories = _context.IshopCategory.ToList().Count();
            ViewBag.totalProducts = _context.IshopProduct.ToList().Count();
            ViewBag.activeSU = _context.IshopSystemUser.Where(abc => abc.SuStatus == true).ToList().Count();
            ViewBag.totalSU = _context.IshopSystemUser.ToList().Count();
            return true;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Login()
        {
            var iShopBusinessSetting = _context.IshopBusinessSetting.FirstOrDefault();
            ViewBag.iShopBusiness = iShopBusinessSetting;
            HttpContext.Session.SetString("SessionBusinessName", iShopBusinessSetting.BusinessName);


            return View();
        }

        public string LoginCheck(string SuUsername, string SuPassword)
        {
            if (SuUsername != "" || SuPassword != "")
            {
                IshopSystemUser su = _context.IshopSystemUser.FirstOrDefault(s => s.SuUsername == SuUsername && s.SuPassword == SuPassword);

                if (su != null)
                {
                    if (su.SuStatus == true)
                    {
                        HttpContext.Session.SetString("SessionUsername", su.SuUsername);
                        HttpContext.Session.SetString("SessionUserRole", su.SuRole);

                        return "true";
                    }
                    else { return "inactive"; }
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "false";
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }



    }
}

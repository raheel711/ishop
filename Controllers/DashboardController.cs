using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ishop.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ishop.Controllers
{
    public class DashboardController : Controller
    {
        Helper Hlp = new Helper();


        //How to use this function in Helper folders
        public bool AuthenticateUser()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionUsername")))
            {
                return false;
            }
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
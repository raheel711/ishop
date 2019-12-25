using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ishop.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}
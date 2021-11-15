using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sampleweb.Models;


namespace sampleweb.Controllers
{
    public class HomeController : Controller
    {
        private  readonly shapiContext _context;
        public HomeController( shapiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var obj = _context.Stores.ToList();
            return View(obj);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}

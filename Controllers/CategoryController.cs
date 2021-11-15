using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sampleweb.Models;

namespace sampleweb.Controllers
{
    [Route("[controller]")]
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        private  readonly shapiContext _context;
        public CategoryController( shapiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create( Category cat ){

            if(ModelState.IsValid){
               
                _context.Categories.Add(cat);
                _context.SaveChanges();
            
                return RedirectToAction("Index");
            }
            return View(cat);

            
        }

         public IActionResult Update(int id){
            var cat = _context.Categories.Where(q => q.Id == id).FirstOrDefault();
            return View(cat);

        }

        [HttpPost]
        public IActionResult Update( Category cat){
            
            if(ModelState.IsValid){
               
                _context.Categories.Update(cat);
                _context.SaveChanges();
               
                return RedirectToAction("Index");
            }
            return View(cat);


        }
    }
}
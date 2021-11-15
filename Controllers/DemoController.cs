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
    // [Route("[controller]")]
    // [Route("[controller]/[action]")]
    public class DemoController : Controller
    {
        private  readonly shapiContext _context;
        public DemoController(shapiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category ctg){
            
            _context.Categories.Add(ctg);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_context.Categories.Where(q => q.Id == id).FirstOrDefault());
        }

        [HttpPost]
         public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid){
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }


         public IActionResult Delete(int id)
        {
            var model = _context.Categories.Where(q => q.Id == id).FirstOrDefault();
            _context.Categories.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
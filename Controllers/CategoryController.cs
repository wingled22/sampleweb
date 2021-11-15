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

        public IActionResult Edit(int id){
            var category = _context.Categories.Where(q => q.Id == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category){
            
            if(ModelState.IsValid){
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int id){
            var catToBeDeleted = _context.Categories.Where(q => q.Id == id).FirstOrDefault();

            _context.Categories.Remove(catToBeDeleted);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
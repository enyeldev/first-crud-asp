using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FirstCrudWeb.Data;
using FirstCrudWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstCrudWeb.Controllers
{
    public class StudentsController : Controller
    {
        private readonly FirstCrudDbContext _context;
        public StudentsController(FirstCrudDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var studentsList = _context.Students.Where(s => s.Deleted == false).ToList();

            return View(studentsList);
        }

        // Get
        public IActionResult Create()
        {
            
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Student vm)
        {
            
            _context.Students.Add(vm);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult Edit(int id)
        {
            var studentEdit = _context.Students.FirstOrDefault(s => s.Id == id);

            if (studentEdit == null)
            {
                NotFound();
            }

            return View(studentEdit);
        }

        [HttpPost]
        public IActionResult Edit(Student vm)
        {
            _context.Students.Update(vm);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            
            if (student == null)
            {
                return NotFound(); 
            }


            return View(student);
        }

        public IActionResult DeleteInDb(int Id)
        {

            var student = _context.Students.Find(Id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();



            return RedirectToAction(nameof(Index));
        }
    }
}
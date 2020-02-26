using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FM.UI.Site.Data;
using FM.UI.Site.Model;
using Microsoft.AspNetCore.Mvc;

namespace FM.UI.Site.Controllers
{
    public class StudentController : Controller
    {
        private readonly MyDbContext _context;

        public StudentController(MyDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var student = new Student()
            {
                Name = "Test",
                Date = DateTime.Now.AddYears(-1),
                Email = "fm@fmsoft.com.br"
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            var savedStudent = _context.Students.FirstOrDefault(c => c.Email == "fm@fmsoft.com.br");

            return View(savedStudent);
        }
    }
}
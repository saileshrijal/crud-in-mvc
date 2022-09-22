using crud.Data;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class Student : Controller
    {
        private readonly StudentsDetailDbContext _context;

        public Student(StudentsDetailDbContext context)
        {
            _context = context;
        }

        //route => domain/student/index or domain/student
        public IActionResult Index()
        {
            var ListOfStudents = _context.StudentsDetails.ToList(); //getting lists of students from database
            return View(ListOfStudents); //passing lists of students to Student/Index view
        }
    }
}

using crud.Data;
using crud.Models;
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel addStudentRequest) {
            var student = new StudentDetails()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Faculty = addStudentRequest.Faculty,
                Email = addStudentRequest.Email,
                Address = addStudentRequest.Address,
            };
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

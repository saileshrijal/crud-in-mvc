using crud.Data;
using crud.Models;
using crud.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Add(StudentViewModel addStudentRequest) {
            try
            {
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
            }catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        //route=> domain/student/edit/id
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var student = await _context.StudentsDetails.FirstOrDefaultAsync(x => x.Id == id); //fetching student by id
                if (student != null)
                {
                    var studentVM = new StudentViewModel()//passing data from model to view model
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Faculty = student.Faculty,
                        Email = student.Email,
                        Address = student.Address
                    };
                    return View(studentVM);//passing student to edit view
                }
                else
                {
                    return Content($"Student not found of ID: {id}");//message if student not found of selected id
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new StudentDetails() // passing viewmodel's data to model
                    {
                        Id = vm.Id,
                        Name = vm.Name,
                        Faculty = vm.Faculty,
                        Email = vm.Email,
                        Address = vm.Address,
                    };
                    _context.StudentsDetails.Update(student);//updaing student
                    await _context.SaveChangesAsync(); //saving changes
                    return RedirectToAction(nameof(Index)); // redirecting to index page after update successfully
                }
                return View(vm);//return view with viewmodel if state is not valid
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
      
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var student = await _context.StudentsDetails.FirstOrDefaultAsync(x => x.Id == id);
                if(student != null)
                {
                    _context.StudentsDetails.Remove(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}

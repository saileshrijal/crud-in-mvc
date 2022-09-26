using crud.Data;
using crud.Models;
using crud.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace crud.Controllers
{
    public class Faculty : Controller
    {
        private readonly StudentsDetailDbContext _context;

        public Faculty(StudentsDetailDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ListOfFaculty = _context.FacultyDetails.ToList();
            return View(ListOfFaculty);
        }

        [HttpGet]
        public IActionResult AddFaculty() { return View(); }

        [HttpPost]
        public async Task<IActionResult> AddFaculty(FacultyViewModel addFacultyRequest)
        {
            try
            {
                var faculty = new FacultyDetails()
                {
                    Id = Guid.NewGuid(),
                    FacultyName = addFacultyRequest.FacultyName,
                  
                };
                await _context.FacultyDetails.AddAsync(faculty);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> Edit(Guid id) {
            try
            {
                var faculty = await _context.FacultyDetails.FirstOrDefaultAsync(x => x.Id == id); //fetching student by id
                if (faculty != null)
                {
                    var FacultyVM = new FacultyViewModel()//passing data from model to view model
                    {
                        Id = faculty.Id,
                        FacultyName = faculty.FacultyName,
                        
                    };
                    return View(FacultyVM);//passing student to edit view
                }
                else
                {
                    return Content($"Faculty not found of ID: {id}");//message if student not found of selected id
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(FacultyViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var faculty = new FacultyDetails() // passing viewmodel's data to model
                    {
                        Id = vm.Id,
                        FacultyName = vm.FacultyName,
                       
                    };
                    _context.FacultyDetails.Update(faculty);//updaing student
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

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var faculty = await _context.FacultyDetails.FirstOrDefaultAsync(x => x.Id == id);
                if (faculty != null)
                {
                    _context.FacultyDetails.Remove(faculty);
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

        

        


using Microsoft.AspNetCore.Mvc.Rendering;

namespace crud.ViewModels
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? FacultyId { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public List<SelectListItem>? Faculties { get; set; }
    }
}

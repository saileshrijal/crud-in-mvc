namespace crud.Models
{
    public class StudentDetails
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid FacultyId { get; set; }
        public FacultyDetails? Faculty { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}

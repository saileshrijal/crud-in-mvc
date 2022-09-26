using crud.Models;
using Microsoft.EntityFrameworkCore;
using crud.ViewModels;

namespace crud.Data
{
    public class StudentsDetailDbContext : DbContext
    {
        public StudentsDetailDbContext(DbContextOptions options): base(options){
        
        }
        public DbSet<StudentDetails>? StudentsDetails { get; set; } 
        public DbSet<FacultyDetails>? FacultyDetails { get; set; }
    }
}

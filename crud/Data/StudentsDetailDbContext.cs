using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class StudentsDetailDbContext : DbContext
    {
        public StudentsDetailDbContext(DbContextOptions options): base(options){
        
        }
        public DbSet<StudentDetails> StudentsDetails { get; set; } 
    }
}

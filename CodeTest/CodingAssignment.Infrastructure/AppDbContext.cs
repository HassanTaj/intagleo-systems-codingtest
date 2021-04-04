using CodingAssignment.DTOs;
using System.Data.Entity;

namespace CodingAssignment.Infrastructure {
    public class AppDbContext : DbContext {
        public AppDbContext() : base("AppDbConnection") {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses{ get; set; }
    }
}

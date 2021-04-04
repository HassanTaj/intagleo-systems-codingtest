using CodingAssignment.DTOs;
using CodingAssignment.Infrastructure;
using CodingAssignment.Services.Interfaces;
using CodingAssignment.Services.Repositories;

namespace CodingAssignment.Services.Implementation {
    /// <summary>
    ///  this class uses generic implementation of generic Repository
    /// </summary>
    internal class CourseService : Repository<Course>, ICourseService {
        public CourseService(AppDbContext db) : base(db) {
        }
    }
}

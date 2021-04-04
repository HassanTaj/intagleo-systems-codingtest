using CodingAssignment.DTOs;
using CodingAssignment.Infrastructure;
using CodingAssignment.Services.Interfaces;
using CodingAssignment.Services.Repositories;

namespace CodingAssignment.Services.Implementation {
    internal class StudentCourseService : Repository<StudentCourse>, IStudentCourseService {
        // this is for later usage
        private readonly AppDbContext _db;
        public StudentCourseService(AppDbContext db) : base(db) {
            _db = db;
        }
    }
}

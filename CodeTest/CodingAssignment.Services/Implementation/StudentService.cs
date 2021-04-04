using CodingAssignment.DTOs;
using CodingAssignment.Infrastructure;
using CodingAssignment.Services.Interfaces;
using CodingAssignment.Services.Repositories;

namespace CodingAssignment.Services.Implementation {
    internal class StudentService : Repository<Student>, IStudentService {
        // this is for later usage
        private readonly AppDbContext _db;
        public StudentService(AppDbContext db) : base(db) {
            _db = db;
        }
    }
}

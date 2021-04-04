using CodingAssignment.DTOs;
using CodingAssignment.Services.Repositories;

namespace CodingAssignment.Services.Interfaces {
    /// <summary>
    ///  This is a tagging interface for that will make it easy for binding
    /// </summary>
    public interface IStudentService : IRepository<Student> {
        // can add custom methods here
    }
}

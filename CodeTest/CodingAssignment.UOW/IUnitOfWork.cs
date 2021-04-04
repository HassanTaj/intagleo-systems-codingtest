using CodingAssignment.Services.Interfaces;

namespace CodingAssignment.UOW {
    public interface IUnitOfWork {
        IStudentService StudentService { get; }
        IStudentCourseService StudentCourseService { get; }
        ICourseService CourseService { get; }
    }
}

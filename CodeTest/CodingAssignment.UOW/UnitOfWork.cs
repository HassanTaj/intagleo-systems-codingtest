using CodingAssignment.Services.Interfaces;
using Ninject;
using static CodingAssignment.UOW.UnitOfWorkRegisteration;
namespace CodingAssignment.UOW {
    internal class UnitOfWork : IUnitOfWork {
        public IStudentService StudentService => GlobalKernel.Get<IStudentService>();
        public ICourseService CourseService => GlobalKernel.Get<ICourseService>();
        public IStudentCourseService StudentCourseService => GlobalKernel.Get<IStudentCourseService>();
    }
}

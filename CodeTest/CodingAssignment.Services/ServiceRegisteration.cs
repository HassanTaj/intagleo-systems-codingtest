using CodingAssignment.Infrastructure;
using CodingAssignment.Services.Implementation;
using CodingAssignment.Services.Interfaces;
using Ninject;

namespace CodingAssignment.Services {
    public static class ServiceRegisteration {
        /// <summary>
        /// Extension Method that registers required services for the application.
        /// </summary>
        /// <param name="kernal"></param>
        public static void BindAppServices(this IKernel kernal) {
            kernal.Bind<AppDbContext>().ToSelf();
            kernal.Bind<IStudentCourseService>().To<StudentCourseService>();
            kernal.Bind<IStudentService>().To<StudentService>();
            kernal.Bind<ICourseService>().To<CourseService>();
        }
    }
}

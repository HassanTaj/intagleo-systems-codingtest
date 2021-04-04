using Ninject;
using static CodingAssignment.Services.ServiceRegisteration;

namespace CodingAssignment.UOW {
    /// <summary>
    /// This class is the middle ware that can be changed later on
    /// </summary>
    public static class UnitOfWorkRegisteration {
        /// <summary>
        /// Global kernal to register/bind services together internally
        /// </summary>
        internal static IKernel GlobalKernel { get; private set; }
        /// <summary>
        /// Method Binds the Unit of Work and all ther services registered
        /// can be used as an extension method
        /// </summary>
        /// <param name="kernal"></param>
        public static void BindUOW(this IKernel kernal) {
            kernal.BindAppServices();
            kernal.Bind<IUnitOfWork>().To<UnitOfWork>();
            GlobalKernel = kernal;
        }
    }
}

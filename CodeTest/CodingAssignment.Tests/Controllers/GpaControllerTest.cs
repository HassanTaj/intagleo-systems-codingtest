using CodingAssignment.Areas.api.Controllers;
using CodingAssignment.Areas.api.Data;
using CodingAssignment.DTOs;
using CodingAssignment.Services.Interfaces;
using CodingAssignment.UOW;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace CodingAssignment.Tests.Controllers {
    [TestClass]
    public class GpaControllerTest {

        [TestMethod]
        public void Get_RollNoNull_ReturnsBadRequest() {
            // Arrange
            Mock<IUnitOfWork> uow = new Mock<IUnitOfWork>();
            GpaController controller = new GpaController(uow.Object);

            // Act
            IHttpActionResult result = controller.Get("") as IHttpActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Get_StudentNull_ReturnsNotFound() {
            // Arrange
            Mock<IUnitOfWork> uow = new Mock<IUnitOfWork>();
            Mock<IStudentService> studentService = new Mock<IStudentService>();
            Mock<IStudentCourseService> studentCourseService = new Mock<IStudentCourseService>();
            uow.Setup(x => x.StudentCourseService).Returns(studentCourseService.Object);
            uow.Setup(x => x.StudentService).Returns(studentService.Object);

            GpaController controller = new GpaController(uow.Object);

            // Act
            IHttpActionResult result = controller.Get("fin-34") as IHttpActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }

        [TestMethod]
        public void Get_StudentRoll_ReturnsOK_StudentGpaResponse() {
            // Arrange
            Mock<IUnitOfWork> uow = new Mock<IUnitOfWork>();
            Mock<IStudentService> studentService = new Mock<IStudentService>();
            Mock<IStudentCourseService> studentCourseService = new Mock<IStudentCourseService>();

            Func<Student, bool> tesdel = x => x.RollNo.Equals("tes-1",System.StringComparison.OrdinalIgnoreCase);
            var expectedStudent = new Student {
                Name = "Test Student",
                Address = "test addr",
                Email = "ta@test.com",
                Phone = "00000000",
                RollNo = "tes-1",
                StudentCourses = new List<StudentCourse> {
                        new StudentCourse {
                            Course = new Course {
                                CourseNo = "tc-1",
                                Name = "tect course 1"
                            },
                            ObtainedMarks = 70,
                        }
                    }
            };
            studentService.SetReturnsDefault<Student>(expectedStudent);
            studentService.Setup(ms => ms.GetSingle(tesdel)).Returns(expectedStudent).Verifiable();
            uow.Setup(x => x.StudentCourseService).Returns(studentCourseService.Object);
            uow.Setup(x => x.StudentService).Returns(studentService.Object);

            GpaController controller = new GpaController(uow.Object);

            // Act
            IHttpActionResult result = controller.Get("tes-1") as IHttpActionResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<StudentGpaResponse>));
        }
    }
}

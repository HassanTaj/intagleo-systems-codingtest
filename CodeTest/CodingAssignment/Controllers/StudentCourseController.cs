using CodingAssignment.DTOs;
using CodingAssignment.Models;
using CodingAssignment.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingAssignment.Controllers {
    public class StudentCourseController : Controller {
        private IUnitOfWork _uow;
        public StudentCourseController(IUnitOfWork uow) {
            _uow = uow;
        }


        [HttpGet]
        // id = student's id
        public ActionResult AddOrUpdateStudentCourse(int? id) {
            int? studentId = Convert.ToInt32(HttpContext.Request.QueryString["sid"]);
            List<SelectListItem> coursesSelectList = new List<SelectListItem>();
            var m = new StudentCourse();
            if (studentId.HasValue && studentId.Value > 0) {
                var student = _uow.StudentService.GetSingle(x => x.Id == studentId.Value);
                var studentOptedCources = student.StudentCourses?.Select(x => x.Course.Id).ToList();
                var avaiableCources = _uow.CourseService.GetList(x => !studentOptedCources.Contains(x.Id));
                coursesSelectList = avaiableCources.ToSelectItemList();
                m = new StudentCourse {
                    StudentId = studentId.Value,
                };
            }
            var courseListDisabled = false;
            if (id.HasValue && id.Value > 0) {
                m = _uow.StudentCourseService.GetSingle(x => x.Id == id.Value);
                var avaiableCources = _uow.CourseService.GetList(x => x.Id==m.CourseId);
                coursesSelectList = avaiableCources.ToSelectItemList();
                coursesSelectList.Find(x => x.Value == m.CourseId.ToString()).Selected = true;
                courseListDisabled = true;
            }

            ViewBag.CourseListDisabled = courseListDisabled;
            ViewBag.CourseSelectList = coursesSelectList;
            return PartialView(nameof(AddOrUpdateStudentCourse), m);
        }

        [HttpPost]
        public ActionResult AddOrUpdateStudentCourse(int? id, StudentCourse m) {
            if (id.HasValue && id.Value > 0) {
                var e = _uow.StudentCourseService.GetSingle(x => x.Id == id.Value);
                e.ObtainedMarks = m.ObtainedMarks;
                _uow.StudentCourseService.Update(e);
            }
            else {
                _uow.StudentCourseService.Create(m);
            }

            return RedirectToAction(nameof(HomeController.StudentCourses), "Home");
        }
    }
}
using CodingAssignment.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingAssignment.Controllers {
    public class HomeController : Controller {
        private IUnitOfWork _uow;
        public HomeController(IUnitOfWork uow) {
            _uow = uow;
        }
        public ActionResult Index() {
            return View();
        }

        public ActionResult Students() {

            return View(_uow.StudentService.GetAll().ToList());
        }

        public ActionResult StudentCourses() {
            return View(_uow.StudentService.GetAll().ToList());
        }
        public ActionResult GpaCalculator() {
            return View();
        }
    }
}
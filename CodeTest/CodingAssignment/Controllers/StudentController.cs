using CodingAssignment.DTOs;
using CodingAssignment.UOW;
using System;
using System.Diagnostics;
using System.Net;
using System.Web.Mvc;

namespace CodingAssignment.Controllers {
    public class StudentController : Controller {

        private IUnitOfWork _uow;
        public StudentController(IUnitOfWork uow) {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult CreateOrUpdate(int? id) =>
            View((id.HasValue && id.Value > 0) ? _uow.StudentService.GetSingle(x => x.Id == id.Value) : new Student());

        [HttpPost]
        public ActionResult CreateOrUpdate(int? id, Student m) {
            try {
                if (id.HasValue && id.Value > 0) {
                    _uow.StudentService.Update(m);
                }
                else {
                    _uow.StudentService.Create(m);
                }
            }
            catch (System.Exception ex) {
                Debug.WriteLine(ex.Message);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, Student m) {
            try {
                if (id > 0) {
                    _uow.StudentService.Remove(_uow.StudentService.GetSingle(x => x.Id == id));
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

    }
}
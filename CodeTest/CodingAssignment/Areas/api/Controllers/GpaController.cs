using CodingAssignment.Areas.api.Data;
using CodingAssignment.UOW;
using System.Linq;
using System.Web.Http;

namespace CodingAssignment.Areas.api.Controllers {
    [RoutePrefix("api/gpa")]
    public class GpaController : ApiController {
        private IUnitOfWork _uow;
        public GpaController(IUnitOfWork uow) {
            _uow = uow;
        }

        [Route("{rollNo}")]
        public IHttpActionResult Get(string rollNo) {
            if (string.IsNullOrEmpty(rollNo)) return BadRequest();

            var std = _uow.StudentService.GetSingle(x => x.RollNo.Equals(rollNo, System.StringComparison.OrdinalIgnoreCase));
            if (std == null) return NotFound();

            var res = new StudentGpaResponse() {
                Name = std.Name,
                RollNo = std.RollNo,
            };

            if (std.StudentCourses.Count > 0) {
                foreach (var sc in std.StudentCourses) {
                    var g = new Gpa() {
                        CourseName = sc.Course?.Name,
                        CourseNo = sc.Course?.CourseNo,
                        ObtainedMarks = sc.ObtainedMarks,
                    };
                    g.CalculateGrade();
                    g.CalculateGradePoint();
                    res.Gpas.Add(g);
                }
            }


            return Ok(res);
        }

        [Route("{rollNo}/{courseNo}")]
        public IHttpActionResult Get(string rollNo, string courseNo) {
            if (string.IsNullOrEmpty(rollNo)) return BadRequest();

            var std = _uow.StudentService.GetSingle(x => x.RollNo.Equals(rollNo, System.StringComparison.OrdinalIgnoreCase));
            if (std == null) return NotFound();

            var res = new StudentGpaResponse() {
                Name = std.Name,
                RollNo = std.RollNo,
            };

            if (std.StudentCourses.Count > 0) {
                var course = std.StudentCourses.Where(x => x.Course.CourseNo.Equals(courseNo, System.StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (course == null) return NotFound();

                var g = new Gpa {
                    CourseName = course.Course?.Name,
                    CourseNo = course.Course?.CourseNo,
                    ObtainedMarks = course.ObtainedMarks
                };
                g.CalculateGrade();
                g.CalculateGradePoint();
                res.Gpas.Add(g);
            }


            return Ok(res);
        }
    }
}

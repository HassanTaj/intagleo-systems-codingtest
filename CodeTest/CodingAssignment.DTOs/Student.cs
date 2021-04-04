using System.Collections.Generic;
using System.ComponentModel;

namespace CodingAssignment.DTOs {
    public class Student : DefaultDto {
        public string Name { get; set; }

        [DisplayName("Roll #")]
        public string RollNo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}

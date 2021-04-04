using System.ComponentModel;

namespace CodingAssignment.DTOs {
    public class Course : DefaultDto {
        public string Name { get; set; }

        [DisplayName("Course No")]
        public string CourseNo { get; set; }
    }
}

using System.ComponentModel;

namespace CodingAssignment.DTOs {
    public class StudentCourse : DefaultDto {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [DisplayName("Obtained Marks")]
        public int ObtainedMarks { get; set; }
    }
}

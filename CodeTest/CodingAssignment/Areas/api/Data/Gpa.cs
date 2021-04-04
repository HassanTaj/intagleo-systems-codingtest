namespace CodingAssignment.Areas.api.Data {
    public class Gpa {
        public Gpa() {
            CalculateGrade();
            CalculateGrade();
        }
        public string CourseName { get; set; }
        public string CourseNo { get; set; }
        public int ObtainedMarks { get; set; }
        public double Percentage => ((double)((double)ObtainedMarks / (double)100) * (double)100);
        public string Grade { get; set; }
        public void CalculateGrade() {
            var grade = "";
            if (Percentage >= 97 && Percentage <= 100) grade = "A+";
            else if (Percentage >= 93 && Percentage <= 96) grade = "A";
            else if (Percentage >= 90 && Percentage <= 92) grade = "A-";

            else if (Percentage >= 87 && Percentage <= 89) grade = "B+";
            else if (Percentage >= 83 && Percentage <= 86) grade = "B";
            else if (Percentage >= 80 && Percentage <= 82) grade = "B-";

            else if (Percentage >= 77 && Percentage <= 79) grade = "C+";
            else if (Percentage >= 73 && Percentage <= 76) grade = "C";
            else if (Percentage >= 70 && Percentage <= 72) grade = "C-";

            else if (Percentage >= 67 && Percentage <= 69) grade = "D+";
            else if (Percentage >= 65 && Percentage <= 66) grade = "D";
            else grade = "F";


            Grade = grade;
        }
        public double GradePoint { get; set; }
        public void CalculateGradePoint() {
            double gp;
            if (Percentage >= 97 && Percentage <= 100) gp = 4.0d;
            else if (Percentage >= 93 && Percentage <= 96) gp = 4.0d;
            else if (Percentage >= 90 && Percentage <= 92) gp = 3.7d;

            else if (Percentage >= 87 && Percentage <= 89) gp = 3.3d;
            else if (Percentage >= 83 && Percentage <= 86) gp = 3.0d;
            else if (Percentage >= 80 && Percentage <= 82) gp = 2.7d;

            else if (Percentage >= 77 && Percentage <= 79) gp = 2.3d;
            else if (Percentage >= 73 && Percentage <= 76) gp = 2.0d;
            else if (Percentage >= 70 && Percentage <= 72) gp = 1.7d;

            else if (Percentage >= 67 && Percentage <= 69) gp = 1.3d;
            else if (Percentage >= 65 && Percentage <= 66) gp = 1.0d;
            else gp = 0.0d;

            GradePoint = gp;
        }
    }
}
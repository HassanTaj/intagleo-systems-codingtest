using CodingAssignment.DTOs;
using System.Collections.Generic;

namespace CodingAssignment.Areas.api.Data {
    public class StudentGpaResponse {
        public StudentGpaResponse() {
            Gpas = new List<Gpa>();
        }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public List<Gpa> Gpas { get; set; }
    }
}
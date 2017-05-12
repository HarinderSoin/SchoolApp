using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolApp.Models;

namespace SchoolApp.DTO
{
    public class StudentAssessmentDTO
    {
        public int ID { get; set; }
        public Student Student { get; set; }
        public int StudentID { get; set; }
        public Subject Subject { get; set; }
        public int SubjectID { get; set; }
        public Grade Grade { get; set; }
        public int GradeID { get; set; }
        public AssessmentGrades AssessmentGrades { get; set; }
        public int AssessmentGradesID { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public int AcademicYearID { get; set; }
        public DateTime AssessmentDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}
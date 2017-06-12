using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.ResultSets
{
    public class StudentAssessmentRS
    {
        public int StudentAssessmentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSubject { get; set; }
        public string StudentGrade { get; set; }
        public string AcademicYear { get; set; }
        public string AssessmentGrade { get; set; }
        public DateTime AssessmentDate { get; set; }
        public string InsertUser { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
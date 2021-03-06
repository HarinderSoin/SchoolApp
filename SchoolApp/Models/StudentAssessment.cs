﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class StudentAssessment
    {
        public int ID { get; set; }
        public Student Student { get; set; }
        public int StudentID { get; set; }
        public ClassAllocation ClassAllocation { get; set; }
        public int ClassAllocationID { get; set; }
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
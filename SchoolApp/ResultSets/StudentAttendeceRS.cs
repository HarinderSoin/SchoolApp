using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.ResultSets
{
    public class StudentAttendeceRS
    {
        public int StudentAttendenceID { get; set; }
        public int ClassAllocationID { get; set; }
        public int StudentAllocationID { get; set; }
        public int SubjectID { get; set; }
        public int GradeID { get; set; }
        public int ClassPeriodID { get; set; }
        public int SemesterID { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string GradeName { get; set; }
        public string ClassPeriod { get; set; }
        public string Semester { get; set; }
        public DateTime AttendenceDate { get; set; }
        public bool IsPresent { get; set; }
        public string InsertUser { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
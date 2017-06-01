using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class StudentAssignmentByTeacherRS
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string ParentEmail { get; set; }
        public string ParentPhone { get; set; }
        public string SubjectName { get; set; }
        public string RoomName { get; set; }
        public string GradeName { get; set; }
        public string ClassPeriod { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public int AcademicYearId { get; set; }
        public string SchoolYear { get; set; }
    }
}
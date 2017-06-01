using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class StudentAssignmentRS
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string ClassLevel { get; set; }
        public string RoomName { get; set; }
        public string ClassPeriod { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public int AcademicYearID { get; set; }
        public string SchoolYear { get; set; }
    }
}
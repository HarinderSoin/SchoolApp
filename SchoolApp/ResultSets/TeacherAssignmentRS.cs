using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.ResultSets
{
    public class TeacherAssignmentRS
    {
        public int ID { get; set; }
        public string TeacherLogin { get; set; }
        public string TeacherName { get; set; }
        public int SubjectID { get; set; }
        public int GradeID { get; set; }
        public int AcademicYearId { get; set; }
        public string SubjectName { get; set; }
        public string GradeName { get; set; }
        public string ClassPeriod { get; set; }
        public string RoomName { get; set; }
        public string SchoolYear { get; set; }
    }
}
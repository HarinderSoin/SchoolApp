using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.ResultSets
{
    public class TeacherSubjectGradeRS
    {
        public string TeacherName { get; set; }
        public int TeacherID { get; set; }
        public string TeacherUserID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int GradeID { get; set; }
        public string GradeName { get; set; }


    }
}
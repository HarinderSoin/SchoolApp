using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class StudentAllocation
    {
        public int ID { get; set; }
        public Student Student  { get; set; }
        public int StudentID { get; set; }
        public Subject Subject { get; set; }
        public int SubjectID { get; set; }
        public Grade  Grade{ get; set; }
        public int GradeID { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public int AcademicYearID { get; set; }
    }
}
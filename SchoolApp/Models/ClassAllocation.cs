using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolApp.DTO;

namespace SchoolApp.Models
{
    public class ClassAllocation
    {
        public int ID { get; set; }
        public Grade Grade { get; set; }
        public int GradeID { get; set; }
        public ClassPeriod ClassPeriod { get; set; }
        public int ClassPeriodID { get; set; }
        public Subject Subject { get; set; }
        public int SubjectID { get; set; }
        public Room Room { get; set; }
        public int RoomID { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public int AcademicYearID { get; set; }
    }
}
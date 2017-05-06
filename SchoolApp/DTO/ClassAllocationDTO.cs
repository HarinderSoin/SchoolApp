using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolApp.Models;

namespace SchoolApp.DTO
{
    public class ClassAllocationDTO
    {
        public int ID { get; set; }

        public int GradeID { get; set; }
        public GradeDTO Grade { get; set; }
        public ClassPeriodDTO ClassPeriod { get; set; }
        public int ClassPeriodID { get; set; }
        public SubjectDTO Subject { get; set; }
        public int SubjectID { get; set; }
        public RoomDTO Room { get; set; }
        public int RoomID { get; set; }
        public AcademicYearDTO AcademicYear { get; set; }
        public int AcademicYearID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolApp.Models;

namespace SchoolApp.DTO
{
    public class TeacherAssignmentDTO
    {
        public int ID { get; set; }

        public Teacher Teacher { get; set; }

        public int TeacherID { get; set; }
        public int ClassAllocationID { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public int AcademicYearID { get; set; }

        public DateTime InsertDate { get; set; }
        public string InsertUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}
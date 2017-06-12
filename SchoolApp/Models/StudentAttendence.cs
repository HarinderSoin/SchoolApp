using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class StudentAttendence
    {
        public int id { get; set; }
        public StudentAssignment StudentAssignment { get; set; }
        public int StudentAssignmentID { get; set; }
        public DateTime AttendenceDate { get; set; }
        public bool IsPresent { get; set; }
        public string InsertUser { get; set; }
        public DateTime InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
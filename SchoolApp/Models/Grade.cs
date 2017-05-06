using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace SchoolApp.Models
{
    public class Grade
    {
        public int ID { get; set; }
        public int ClassGrade { get; set; }
        public string ClassDescription { get; set; }

    }
}
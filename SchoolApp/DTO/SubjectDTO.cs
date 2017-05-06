using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApp.DTO
{
    public class SubjectDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public bool Mandatory { get; set; }
    }
}
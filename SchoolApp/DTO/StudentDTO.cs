using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolApp.Models;

namespace SchoolApp.DTO
{
    public class StudentDTO
    {
        public int ID { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }


        public string MobileNo { get; set; }

        public int ParentID { get; set; }

        public string UserId { get; set; }
    }
}
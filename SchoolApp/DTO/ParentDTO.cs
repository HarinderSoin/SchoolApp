using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SchoolApp.Models;

namespace SchoolApp.DTO
{
    public class ParentDTO
    {
        public int ID { get; set; }
        public string Parent1Name { get; set; }


        public string Parent1LastName { get; set; }


        public string Parent2Name { get; set; }

        public string Parent2LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public State State { get; set; }
        public byte StateID { get; set; }

        public string Zip { get; set; }

        public string HomePhone { get; set; }


        public string Mobile1 { get; set; }

        public string Mobile2 { get; set; }
 
        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public bool Parent1WillVolunteer { get; set; }
        public bool Parent1WillTeach { get; set; }
        public bool Parent2WillVolunteer { get; set; }
        public bool Parent2WillTeach { get; set; }

        public string UserId { get; set; }
    }
}
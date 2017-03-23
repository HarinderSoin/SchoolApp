using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace SchoolApp.Models
{
    public class Student
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string MobileNo { get; set; }

        public Parent parent { get; set; }

        public byte ParentID  { get; set; }
    }
}
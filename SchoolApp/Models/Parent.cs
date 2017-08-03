using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class Parent
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Parent1Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Parent1LastName { get; set; }

       [StringLength(50)]
        public string Parent2Name { get; set; }

        [StringLength(50)]
        public string Parent2LastName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        public State State { get; set; }
        public byte StateID { get; set; }

        [StringLength(20)]
        public string Zip { get; set; }

        [Phone]
        [StringLength(20)]
        public string HomePhone { get; set; }

        [Required]
        [StringLength(20)]
        public string Mobile1 { get; set; }

        [StringLength(20)]
        public string Mobile2 { get; set; }

        [EmailAddress]
        [Required]
        [StringLength(50)]
        public string Email1 { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string Email2 { get; set; }

        public bool Parent1WillVolunteer { get; set; }
        public bool Parent1WillTeach { get; set; }
        public bool Parent2WillVolunteer { get; set; }
        public bool Parent2WillTeach { get; set; }

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}

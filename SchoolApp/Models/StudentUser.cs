using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class StudentUser
    {
        public int ID { get; set; }
        public Student Student { get; set; }
        public int StudentID { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
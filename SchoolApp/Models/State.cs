using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class State
    {
        public byte ID { get; set; }
        public string Name { get; set; }

        [StringLength(2)]
        public string StateAbbr { get; set; }
    }
}
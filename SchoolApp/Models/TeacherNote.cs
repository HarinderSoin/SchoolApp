using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolApp.Models
{
    public class TeacherNote
    {
        public int ID { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public int SubjectID { get; set; }
        public Grade Grade { get; set; }
        public int GradeID { get; set; }
        public AcademicYear AcademicYear {get; set;}
        public int AcademicYearID { get; set; }
        public DateTime NoteDate { get; set; }
        public string AttachmentURL { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }

    }
}
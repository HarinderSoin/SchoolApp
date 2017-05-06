using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolApp.Models;

namespace SchoolApp.ViewModel
{
    public class ClassAllocationVM
    {
        public IEnumerable<Grade> Grades { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        public IEnumerable<AcademicYear> AcademicYears { get; set; }
        public IEnumerable<ClassPeriod> ClassPeriods { get; set; }
        public ClassAllocation ClassAllocation { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using SchoolApp.DTO;
using SchoolApp.Models;
using SchoolApp.ViewModel;

namespace SchoolApp.Controllers
{
    public class ClassAllocationController : Controller
    {
        private ApplicationDbContext _context;

        public ClassAllocationController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }
        // GET: ClassAllocation
        public ActionResult AllocateClass()
        {
            return View("ClassAllocation");
        }

        public ActionResult ListClassAllocations()
        {
            return View("ListClassAllocations");
        }

        public ActionResult ClassAllocationEdit(int id)
        {
            var classAllocationDetail = new ClassAllocation();
            classAllocationDetail = this._context.ClassAllocations.SingleOrDefault(c => c.ID == id);

            var classAllocationVM = new ClassAllocationVM()
            {
                ClassAllocation = classAllocationDetail,
                Rooms = _context.Rooms.ToList(),
                Grades = _context.Grades.ToList(),
                AcademicYears = _context.AcademicYears.ToList(),
                Subjects = _context.Subjects.ToList(),
                ClassPeriods = _context.ClassPeriods.ToList()
            };


            return View("ClassAllocation", classAllocationVM);
        }
    }
}
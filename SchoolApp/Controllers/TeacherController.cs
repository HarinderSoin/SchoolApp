using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApp.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult RegisterTeacher()
        {
            return View("RegisterTeacher");
        }

        public ActionResult TeacherAllocation()
        {
            return View("TeacherAllocation");
        }

        public ActionResult ListTeacherAllocation()
        {
            return View("ListTeacherAllocation");
        }

        public ActionResult ListTeacherAllocationByTeacher()
        {
            return View("ListTeacherAllocationByTeacher");
        }

        public ActionResult ListStudentAllocationByTeacher(int id)
        {
            ViewBag.ClassAllocationID = id;
            return View("ListStudentAllocationByTeacher", id);
        }

        public ActionResult StudentAssessmentByTeacher(int id)
        {
            ViewBag.ClassAllocationID = id;
            return View("EnterStudentAssessmentByTeacher", id);
        }
    }
}

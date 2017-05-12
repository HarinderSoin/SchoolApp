using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApp.Controllers
{
    public class StudentDetailController : Controller
    {
        // GET: StudentDetail
        public ActionResult StudentAssessmentByParent(int id)
        {
            ViewBag.StudentId = id;
            return View("StudentAssessmentByParent", id);
        }
    }
}
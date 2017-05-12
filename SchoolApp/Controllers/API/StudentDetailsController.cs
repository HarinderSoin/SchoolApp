using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SchoolApp.Models;

namespace SchoolApp.Controllers.API
{
    public class StudentDetailsController : ApiController
    {
        //[System.Web.Http.Route("api/[controller]/[action]")]

            private ApplicationDbContext _context;
            private StudentUser studentUser;

            public StudentDetailsController()
            {
                _context = new ApplicationDbContext();
                this.studentUser = new StudentUser();
            }

            [System.Web.Http.HttpGet]
            public IHttpActionResult GetStudentsAssessmentByParent(int id)
            {
                var userId = User.Identity.GetUserId();
                var studentAssessment = (from stu in _context.Students
                    join
                    sa in _context.StudentAssessments
                    on stu.ID equals sa.StudentID
                    join
                    su in _context.StudentUsers
                    on sa.StudentID equals su.StudentID
                    join
                    gr in _context.Grades
                    on sa.GradeID equals gr.ID
                    join
                    sub in _context.Subjects
                    on sa.SubjectID equals sub.ID
                    join
                    ayr in _context.AcademicYears
                    on sa.AcademicYearID equals ayr.ID
                    join
                    ag in _context.AssessmentGrades
                    on sa.AssessmentGradesID equals ag.ID
                    where stu.ID == id
                    select new
                    {
                        Id = stu.ID,
                        studentName = stu.FirstName + " " + stu.LastName,
                        studentSubject = sub.Name,
                        studentGrade = gr.ClassDescription,
                        academicYear = ayr.SchoolYear,
                        assessmentDate = sa.AssessmentDate,
                        assessmentGrade = ag.Description
                    }
                );
                return Ok(studentAssessment);
            }
        }
    }

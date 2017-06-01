using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SchoolApp.DTO;
using SchoolApp.Models;

namespace SchoolApp.Controllers.API
{
    public class StudentDetailsController : ApiController
    {

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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/StudentDetails/GetStudentAssignment")]
        public IHttpActionResult GetStudentAssignment()
        {
            var userId = User.Identity.GetUserId();
            var studentId = new SqlParameter()
            {
                ParameterName = "@StudentID", 
                Value = 0
            };
            var studentAssignment = _context.Database.SqlQuery<StudentAssignmentRS>(
                "EXEC spGetStudentAssignment @StudentID", studentId);
            return Ok(studentAssignment);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/StudentDetails/GetStudentAssignment/{id}")]
        public IHttpActionResult GetStudentAssignmentByID(int id)
        {
            var userId = User.Identity.GetUserId();
            var studentId = new SqlParameter()
            {
                ParameterName = "@StudentID",
                Value = id
            };
            var studentAssignment = _context.Database.SqlQuery<StudentAssignmentByTeacherRS>(
                "EXEC spGetStudentAssignment @StudentID", studentId);
            return Ok(studentAssignment);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/StudentDetails/CreateStudentAssignment")]
        [ValidateAntiForgeryToken]
        public IHttpActionResult CreateStudentAssignment(StudentAssignmentDTO studentAssignmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            studentAssignmentDto.InsertDate = DateTime.Now;
            studentAssignmentDto.UpdateDate = DateTime.Now;

            var studentAssignment = Mapper.Map<StudentAssignmentDTO, StudentAssignment>(studentAssignmentDto);
            
            _context.StudentAssignments.Add(studentAssignment);

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + studentAssignmentDto.ID), studentAssignmentDto);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/StudentDetails/EnterStudentAssessment")]
        public IHttpActionResult EnterStudentAssessment(StudentAssessmentDTO studentAssessmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            studentAssessmentDto.InsertDate = DateTime.Now;
            studentAssessmentDto.UpdateDate = DateTime.Now;

            var userId = User.Identity.GetUserId();

            var studentAssessment = Mapper.Map<StudentAssessmentDTO, StudentAssessment>(studentAssessmentDto);

            _context.StudentAssessments.Add(studentAssessment);

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + studentAssessmentDto.ID), studentAssessmentDto);
        }
    }
    }

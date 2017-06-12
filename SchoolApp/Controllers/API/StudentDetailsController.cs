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
using SchoolApp.ResultSets;

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

                var studentId = new SqlParameter()
                {
                    ParameterName = "@StudentID",
                    Value = id
                };
                var academicYearId = new SqlParameter()
                {
                    ParameterName = "@AcademicYearID",
                    Value = 1
                };

                var studentAssessment = _context.Database.SqlQuery<StudentAssessmentRS>(
                    "EXEC spGetStudentAssessmentByStudent @StudentID, @AcademicYearID", studentId, academicYearId);
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
            var academicYearId = new SqlParameter()
            {
                ParameterName = "@AcademicYearID",
                Value = 1
            };

            var studentAssignment = _context.Database.SqlQuery<StudentAssignmentRS>(
                "EXEC spGetStudentAssignment @StudentID, @AcademicYearID", studentId, academicYearId);
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
            var academicYearId = new SqlParameter()
            {
                ParameterName = "@AcademicYearID",
                Value = 1
            };

            var studentAssignment = _context.Database.SqlQuery<StudentAssignmentRS>(
                "EXEC spGetStudentAssignment @StudentID, @AcademicYearID", studentId, academicYearId);
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

        [System.Web.Http.HttpPost]
        //[ValidateAntiForgeryToken]
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/StudentDetails/GetStudentAttendence/{semesterID}/{classAllocationID}/{teacherID?}")]
        public IHttpActionResult GetStudentAttendence(int semesterID, int classAllocationID, int teacherID)
        {
            var userId = User.Identity.GetUserId();
            var teacherId = new SqlParameter()
            {

                ParameterName = "@TeacherID",
                Value = 0
            };
            var semesterId = new SqlParameter()
            {
                ParameterName = "@SemesterID",
                Value = semesterID
            };
            var classAllocationId = new SqlParameter()
            {
                ParameterName = "@ClassAllocationID",
                Value = classAllocationID
            };



            var studentAttendence = _context.Database.SqlQuery<StudentAttendeceRS>(
                "EXEC spGetClassAttendanceByClass @TeacherID, @SemesterID, @ClassAllocationID", teacherId, semesterId, classAllocationId);
            return Ok(studentAttendence);
        }
    }
    }

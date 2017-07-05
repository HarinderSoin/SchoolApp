using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
    [System.Web.Http.Route("api/[controller]/[action]")]
    public class TeachersController : ApiController
    {

            private ApplicationDbContext _context;

            public TeachersController()
            {
                _context = new ApplicationDbContext();

            }

            [System.Web.Http.HttpPost]
            [System.Web.Http.Route("api/teachers/createTeacher")]
            [ValidateAntiForgeryToken]
        public IHttpActionResult CreateTeacher(TeacherDTO teacherDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var userId = User.Identity.GetUserId();
                teacherDto.UserId = User.Identity.GetUserId();

                var teacher = Mapper.Map<TeacherDTO, Teacher>(teacherDto);
                teacher.InsertDate = DateTime.Now;
                teacher.UpdateDate = DateTime.Now;
                teacher.InsertUser = userId;

                _context.Teachers.Add(teacher);
                _context.SaveChanges();

                teacherDto.ID = teacher.ID;
                return Created(new Uri(Request.RequestUri + "/" + teacherDto.ID), teacherDto);
            }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/teachers/listTeachers")]
        public IHttpActionResult ListTeacher()
        {
            var teacherDto = _context.Teachers
                .ToList()
             .Select(Mapper.Map<Teacher, TeacherDTO>);
            return Ok(teacherDto);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/teachers/teacherAllocation")]
        public IHttpActionResult TeacherAllocation(TeacherAssignmentDTO teacherAssignmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var teacherAssignment = Mapper.Map<TeacherAssignmentDTO, TeacherAssignment>(teacherAssignmentDto);
            teacherAssignment.InsertDate = DateTime.Now;
            teacherAssignment.UpdateDate = DateTime.Now;
            _context.TeachersAssignments.Add(teacherAssignment);
            _context.SaveChanges();

            teacherAssignmentDto.ID = teacherAssignment.ID;
            return Created(new Uri(Request.RequestUri + "/" + teacherAssignmentDto.ID), teacherAssignmentDto);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/teachers/ListTeacherAssignment")]
        public IHttpActionResult ListTeacherAssignment()
        {
            var user = User.Identity.GetUserId();

            var userId = new SqlParameter()
            {
                ParameterName = "@UserId",
                Value = "all"
            };
            var academicYearId = new SqlParameter()
            {
                ParameterName = "@AcademicYearId",
                Value = 1
            };

            var teacherAssignment = _context.Database.SqlQuery<TeacherAssignmentRS>(
                "EXEC spgetTeacherAssignments @UserId, @AcademicYearID", userId, academicYearId);
            return Ok(teacherAssignment);
            
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/teachers/DeleteTeacherAssignment")]
        public IHttpActionResult DeleteTeacherAssignment(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var teacherAllocationInDB = _context.TeachersAssignments.SingleOrDefault(c => c.ID == id);

            if (teacherAllocationInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.TeachersAssignments.Remove(teacherAllocationInDB);
            _context.SaveChanges();

            return Ok();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Teachers/StudentAssignmentByTeacher/{id}")]
        public IHttpActionResult StudentAssignmentByTeacher(int id)
        {
            var user = User.Identity.GetUserId();
            var userId = new SqlParameter()
            {
                ParameterName = "@UserId",
                Value = user
            };
            var classAllocationId = new SqlParameter()
            {
                ParameterName = "@ClassAllocationId",
                Value = id
            };
            var academicYearId = new SqlParameter()
            {
                ParameterName = "@AcademicYearId",
                Value = 1
            };

            var studentAssignment = _context.Database.SqlQuery<StudentAssignmentByTeacherRS>(
                "EXEC spgetStudentAssignmentByTeacher @UserId, @ClassAllocationId, @AcademicYearID", userId, classAllocationId, academicYearId);
            return Ok(studentAssignment);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/teachers/ListTeacherAssignmentByTeacher")]
        public IHttpActionResult ListTeacherAssignmentByTeacher()
        {
            var user = User.Identity.GetUserId();

            var userId = new SqlParameter()
            {
                ParameterName = "@UserId",
                Value = user
            };
            var academicYearId = new SqlParameter()
            {
                ParameterName = "@AcademicYearId",
                Value = 1
            };

            var teacherAssignment = _context.Database.SqlQuery<TeacherAssignmentRS>(
                "EXEC spgetTeacherAssignments @UserId, @AcademicYearID", userId, academicYearId);
            return Ok(teacherAssignment);
            
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/teachers/GetTeacherByUserId")]
        public IHttpActionResult GetTeacherByUserId()
        {
            var user = User.Identity.GetUserId();

            var userId = new SqlParameter()
            {
                ParameterName = "@UserId",
                Value = user
            };
            var academicYearId = new SqlParameter()
            {
                ParameterName = "@AcademicYearId",
                Value = 1
            };

            var teacherAssignment = _context.Database.SqlQuery<TeacherAssignmentRS>(
                "EXEC spgetTeacherAssignments @UserId, @AcademicYearID", userId, academicYearId).GroupBy(s => s.SubjectName);

            return Ok(teacherAssignment);

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/teachers/GetSubjectsByTeacher")]
        public IHttpActionResult GetSubjectsByTeacher()
        {
            var user = User.Identity.GetUserId();

            var userId = new SqlParameter()
            {
                ParameterName = "@UserId",
                Value = user
            };

            var subjectID = new SqlParameter()
            {
                ParameterName = "@SubjectID",
                Value = 0
            };

            var academicYearId = new SqlParameter()
            {
                ParameterName = "@AcademicYearId",
                Value = 1
            };

            var teacherAssignment = _context.Database.SqlQuery<TeacherSubjectGradeRS>(
                "EXEC spSelectDistinctSubjectandGradesForTeacher @UserId, @AcademicYearID, @SubjectID", userId, academicYearId, subjectID);

            return Ok(teacherAssignment);

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/teachers/GetGradesByTeacher/{Id}")]
        public IHttpActionResult GetGradesByTeacher(int Id)
        {
            var user = User.Identity.GetUserId();

            var userId = new SqlParameter()
            {
                ParameterName = "@UserId",
                Value = user
            };

            var subjectID = new SqlParameter()
            {
                ParameterName = "@SubjectID",
                Value = Id
            };

            var academicYearId = new SqlParameter()
            {
                ParameterName = "@AcademicYearId",
                Value = 1
            };

            var teacherAssignment = _context.Database.SqlQuery<TeacherSubjectGradeRS>(
                "EXEC spSelectDistinctSubjectandGradesForTeacher @UserId, @AcademicYearID, @SubjectID", userId, academicYearId, subjectID);

            return Ok(teacherAssignment);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SchoolApp.DTO;
using SchoolApp.Models;
using WebGrease.Css.Ast.Selectors;

namespace SchoolApp.Controllers.API
{
    [System.Web.Http.Route("api/[controller]/[action]")]
    public class StudentController : ApiController
    {
        private ApplicationDbContext _context;
        private StudentUser studentUser;

        public StudentController()
        {
            _context = new ApplicationDbContext();
            this.studentUser = new StudentUser();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Student/CreateStudent")]
        public IHttpActionResult CreateStudent(StudentDTO studentDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var userId = User.Identity.GetUserId();
            studentDto.UserId = User.Identity.GetUserId();

            var student = Mapper.Map<StudentDTO, Student>(studentDto);

            _context.Students.Add(student);

            this.studentUser.StudentID = student.ID;
            this.studentUser.UserId = userId;

            _context.StudentUsers.Add(studentUser);
            _context.SaveChanges();

            studentDto.ID = student.ID; 
            return Created(new Uri(Request.RequestUri + "/" + studentDto.ID), studentDto );
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Student/GetStudents")]
        public IHttpActionResult GetStudents()
        {
            var studentDto = _context.Students
                .Include(p => p.Parent)
                .ToList()
             .Select(Mapper.Map<Student, StudentDTO>);
            return Ok(studentDto);
        } 

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.ID == id); 

            if (student == null)
                return NotFound();

            var studentDto = Mapper.Map<Student, StudentDTO>(student);
            return Ok(studentDto);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/student/getStudentsByParent")]
        [ValidateAntiForgeryToken]
        public IHttpActionResult GetStudentsByParent()
        {
            var userId = User.Identity.GetUserId();
            var student = (from stu in _context.Students
                           join 
                           pr in _context.Parents
                           on 
                           stu.ParentID equals pr.ID
                           where stu.UserId == userId
                           select new
                           {
                               Id= stu.ID,
                               studentName = stu.FirstName + " " + stu.LastName, 
                               studentDOB = stu.DateOfBirth, 
                               parentsName = pr.Parent1Name + " " + pr.Parent1LastName + " & " + pr.Parent2Name + " " + pr.Parent2LastName,
                           }
                           );
            return Ok(student);
        }
    }
}

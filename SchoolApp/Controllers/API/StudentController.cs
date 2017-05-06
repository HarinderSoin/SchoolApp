using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SchoolApp.DTO;
using SchoolApp.Models;
using WebGrease.Css.Ast.Selectors;

namespace SchoolApp.Controllers.API
{
    public class StudentController : ApiController
    {
        private ApplicationDbContext _context;
        private StudentUser studentUser;

        public StudentController()
        {
            _context = new ApplicationDbContext();
            this.studentUser = new StudentUser();
        }

        [HttpPost]
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

        [HttpGet]
       public IHttpActionResult GetStudents()
        {
            var studentDto = _context.Students
                .Include(p => p.Parent)
                .ToList()
             .Select(Mapper.Map<Student, StudentDTO>);
            return Ok(studentDto);
        } 

        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.ID == id); 

            if (student == null)
                return NotFound();

            var studentDto = Mapper.Map<Student, StudentDTO>(student);
            return Ok(studentDto);
        }

        [HttpGet]
        [Route("getStudentsByParent")]
        public IHttpActionResult GetStudentsByParent()
        {
            var userId = User.Identity.GetUserId();
            var student = (from stu in _context.Students
                           join 
                           pr in _context.Parents
                           on 
                           stu.ParentID equals pr.ID
                           where pr.UserId ==userId
                           select new
                           {
                               stu.ID,
                               stu.FirstName, 
                               stu.LastName,
                               stu.DateOfBirth, 
                               pr.Parent1Name,
                               pr.Parent1LastName,
                               pr.Parent2Name,
                               pr.Parent2LastName
                           }
                           );
            return Ok(student);
        }
    }
}

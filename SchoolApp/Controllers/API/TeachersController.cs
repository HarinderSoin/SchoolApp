using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SchoolApp.DTO;
using SchoolApp.Models;

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
            public IHttpActionResult CreateTeacher(TeacherDTO teacherDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var userId = User.Identity.GetUserId();
                teacherDto.UserId = User.Identity.GetUserId();

                var teacher = Mapper.Map<TeacherDTO, Teacher>(teacherDto);

                _context.Teachers.Add(teacher);
                _context.SaveChanges();

                teacherDto.ID = teacher.ID;
                return Created(new Uri(Request.RequestUri + "/" + teacherDto.ID), teacherDto);
            }
        }
}

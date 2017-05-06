using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SchoolApp.DTO;
using SchoolApp.Models;

namespace SchoolApp.Controllers.API
{
    public class GradesController : ApiController
    {
        private ApplicationDbContext _context;

        public GradesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateGrade(GradeDTO GradeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Grade = Mapper.Map<GradeDTO, Grade>(GradeDto);

            _context.Grades.Add(Grade);
            _context.SaveChanges();
            GradeDto.ID = Grade.ID;
            return Created(new Uri(Request.RequestUri + "/" + GradeDto.ID), GradeDto);
        }

        [HttpGet]
        public IHttpActionResult GetGrades()
        {
            var GradeDto = _context.Grades
                .ToList()
                .Select(Mapper.Map<Grade, GradeDTO>);
            return Ok(GradeDto);
        }

        [HttpGet]
        public IHttpActionResult GetGrade(int id)
        {
            var Grade = _context.Grades.SingleOrDefault(c => c.ID == id);
            if (Grade == null)
                return NotFound();
            return Ok(Mapper.Map<Grade, GradeDTO>(Grade));
        }

        [HttpDelete]
        public IHttpActionResult DeleteGrade(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var GradeInDB = _context.Grades.SingleOrDefault(c => c.ID == id);

            if (GradeInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Grades.Remove(GradeInDB);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateGrade(int id, GradeDTO GradeDto)
        {

            var GradeInDB = _context.Grades.SingleOrDefault(c => c.ID == id);

            if (GradeInDB == null)
                NotFound();

            Mapper.Map(GradeDto, GradeInDB);
            _context.SaveChanges();

            return Ok(GradeDto);
        }
    }
}

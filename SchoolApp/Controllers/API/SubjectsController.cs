using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SchoolApp.DTO;
using SchoolApp.Models;

namespace SchoolApp.Controllers.API
{
    public class SubjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public SubjectsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateSubject(SubjectDTO SubjectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Subject = Mapper.Map<SubjectDTO, Subject>(SubjectDto);

            _context.Subjects.Add(Subject);
            _context.SaveChanges();
            SubjectDto.ID = Subject.ID;
            return Created(new Uri(Request.RequestUri + "/" + SubjectDto.ID), SubjectDto);
        }

        [HttpGet]
        public IHttpActionResult GetSubjects()
        {
            var SubjectDto = _context.Subjects
                .ToList()
                .Select(Mapper.Map<Subject, SubjectDTO>);
            return Ok(SubjectDto);
        }

        [HttpGet]
        public IHttpActionResult GetSubject(int id)
        {
            var Subject = _context.Subjects.SingleOrDefault(c => c.ID == id);
            if (Subject == null)
                return NotFound();
            return Ok(Mapper.Map<Subject, SubjectDTO>(Subject));
        }

        [HttpDelete]
        public IHttpActionResult DeleteSubject(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var SubjectInDB = _context.Subjects.SingleOrDefault(c => c.ID == id);

            if (SubjectInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Subjects.Remove(SubjectInDB);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateSubject(int id, SubjectDTO SubjectDto)
        {

            var SubjectInDB = _context.Subjects.SingleOrDefault(c => c.ID == id);

            if (SubjectInDB == null)
                NotFound();

            Mapper.Map(SubjectDto, SubjectInDB);
            _context.SaveChanges();

            return Ok(SubjectDto);
        }
    }
}

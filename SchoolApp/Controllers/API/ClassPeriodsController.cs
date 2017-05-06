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
    public class ClassPeriodsController : ApiController
    {
        private ApplicationDbContext _context;

        public ClassPeriodsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateClassPeriod(ClassPeriodDTO ClassPeriodDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ClassPeriod = Mapper.Map<ClassPeriodDTO, ClassPeriod>(ClassPeriodDto);

            _context.ClassPeriods.Add(ClassPeriod);
            _context.SaveChanges();
            ClassPeriodDto.ID = ClassPeriod.ID;
            return Created(new Uri(Request.RequestUri + "/" + ClassPeriodDto.ID), ClassPeriodDto);
        }

        [HttpGet]
        public IHttpActionResult GetClassPeriods()
        {
            var ClassPeriodDto = _context.ClassPeriods
                .ToList()
                .Select(Mapper.Map<ClassPeriod, ClassPeriodDTO>);
            return Ok(ClassPeriodDto);
        }

        [HttpGet]
        public IHttpActionResult GetClassPeriod(int id)
        {
            var ClassPeriod = _context.ClassPeriods.SingleOrDefault(c => c.ID == id);
            if (ClassPeriod == null)
                return NotFound();
            return Ok(Mapper.Map<ClassPeriod, ClassPeriodDTO>(ClassPeriod));
        }

        [HttpDelete]
        public IHttpActionResult DeleteClassPeriod(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var ClassPeriodInDB = _context.ClassPeriods.SingleOrDefault(c => c.ID == id);

            if (ClassPeriodInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.ClassPeriods.Remove(ClassPeriodInDB);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateClassPeriod(int id, ClassPeriodDTO ClassPeriodDto)
        {

            var ClassPeriodInDB = _context.ClassPeriods.SingleOrDefault(c => c.ID == id);

            if (ClassPeriodInDB == null)
                NotFound();

            Mapper.Map(ClassPeriodDto, ClassPeriodInDB);
            _context.SaveChanges();

            return Ok(ClassPeriodDto);
        }
    }
}

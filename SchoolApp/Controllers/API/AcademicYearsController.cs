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
    public class AcademicYearsController : ApiController
    {
        private ApplicationDbContext _context;

        public AcademicYearsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateAcademicYear(AcademicYearDTO AcademicYearDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var AcademicYear = Mapper.Map<AcademicYearDTO, AcademicYear>(AcademicYearDto);

            _context.AcademicYears.Add(AcademicYear);
            _context.SaveChanges();
            AcademicYearDto.ID = AcademicYear.ID;
            return Created(new Uri(Request.RequestUri + "/" + AcademicYearDto.ID), AcademicYearDto);
        }

        [HttpGet]
        public IHttpActionResult GetAcademicYears()
        {
            var AcademicYearDto = _context.AcademicYears
                .ToList()
                .Select(Mapper.Map<AcademicYear, AcademicYearDTO>);
            return Ok(AcademicYearDto);
        }

        [HttpGet]
        public IHttpActionResult GetAcademicYear(int id)
        {
            var AcademicYear = _context.AcademicYears.SingleOrDefault(c => c.ID == id);
            if (AcademicYear == null)
                return NotFound();
            return Ok(Mapper.Map<AcademicYear, AcademicYearDTO>(AcademicYear));
        }

        [HttpDelete]
        public IHttpActionResult DeleteAcademicYear(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var AcademicYearInDB = _context.AcademicYears.SingleOrDefault(c => c.ID == id);

            if (AcademicYearInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.AcademicYears.Remove(AcademicYearInDB);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateAcademicYear(int id, AcademicYearDTO AcademicYearDto)
        {

            var AcademicYearInDB = _context.AcademicYears.SingleOrDefault(c => c.ID == id);

            if (AcademicYearInDB == null)
                NotFound();

            Mapper.Map(AcademicYearDto, AcademicYearInDB);
            _context.SaveChanges();

            return Ok(AcademicYearDto);
        }
    }
}

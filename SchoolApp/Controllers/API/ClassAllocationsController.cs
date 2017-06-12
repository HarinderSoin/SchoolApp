using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using SchoolApp.DTO;
using SchoolApp.Models;
using SchoolApp.BusinessLogic;

namespace SchoolApp.Controllers.API
{
    public class ClassAllocationsController : ApiController
    {
        private ApplicationDbContext _context;

        public ClassAllocationsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public IHttpActionResult CreateClassAllocation(ClassAllocationDTO ClassAllocationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var classAllocation = Mapper.Map<ClassAllocationDTO, ClassAllocation>(ClassAllocationDto);

            var _validateClassAllocation = new BusinessLogic.ClassAllocation.ClassAllocationValidation();

            var _isClassAllocationValid = _validateClassAllocation.ValidateClassAllocation(classAllocation);

            if (_isClassAllocationValid != "All Tests Passed!")
                return Ok(_isClassAllocationValid);

            _context.ClassAllocations.Add(classAllocation);
            _context.SaveChanges();
            ClassAllocationDto.ID = classAllocation.ID;
            var newUrl = this.Url.Link("Default", new
            {
                Controller = "ClassAllocation",
                Action = "ListClassAllocations"
            });

            return Created(new Uri(Request.RequestUri + "/" + classAllocation.ID), ClassAllocationDto);

        }

        [System.Web.Http.HttpGet]
        [ValidateAntiForgeryToken]
        public IHttpActionResult GetClassAllocations()
        {
            var classAllocationDto = _context.ClassAllocations
                .Include(s => s.Subject)
                .Include(g => g.Grade)
                .Include(r => r.Room)
                .Include(c => c.ClassPeriod)
                .Include(a => a.AcademicYear)
                .ToList()
                .Select(Mapper.Map<ClassAllocation, ClassAllocationDTO>);
            return Ok(classAllocationDto);
        }


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetClassAllocation(int id)
        {
            var ClassAllocation = _context.ClassAllocations.SingleOrDefault(c => c.ID == id);
            if (ClassAllocation == null)
                return NotFound();
            return Ok(Mapper.Map<ClassAllocation, ClassAllocationDTO>(ClassAllocation));
        }

        [System.Web.Http.HttpDelete]
        [ValidateAntiForgeryToken]
        public IHttpActionResult DeleteClassAllocation(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var ClassAllocationInDB = _context.ClassAllocations.SingleOrDefault(c => c.ID == id);

            if (ClassAllocationInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.ClassAllocations.Remove(ClassAllocationInDB);
            _context.SaveChanges();

            return Ok();
        }

        [System.Web.Http.HttpPut]
        [ValidateAntiForgeryToken]
        public IHttpActionResult UpdateClassAllocation(int id, ClassAllocationDTO ClassAllocationDto)
        {

            var ClassAllocationInDB = _context.ClassAllocations.SingleOrDefault(c => c.ID == id);

            if (ClassAllocationInDB == null)
                NotFound();

            Mapper.Map(ClassAllocationDto, ClassAllocationInDB);
            _context.SaveChanges();

            return Ok(ClassAllocationDto);
        }
    }
}

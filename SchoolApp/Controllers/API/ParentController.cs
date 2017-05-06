using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolApp.DTO;
using SchoolApp.Models;

namespace SchoolApp.Controllers.API
{
    public class ParentController : ApiController
    {
        private ApplicationDbContext _context;


        public ParentController()
        {
            _context = new ApplicationDbContext();

        }

        [HttpPost]
        public IHttpActionResult CreateParent(ParentDTO parentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            UserManager<ApplicationUser> userManager;
            var userId = User.Identity.GetUserId();
            parentDto.UserId =   User.Identity.GetUserId();
           
            var parent = Mapper.Map<ParentDTO, Parent>(parentDto);

            _context.Parents.Add(parent);
            _context.SaveChanges();
            parentDto.ID = parent.ID;
            return Created(new Uri(Request.RequestUri + "/" + parentDto.ID), parentDto);
        }

        [HttpGet]
        public IHttpActionResult GetParents()
        {
            var parentDto = _context.Parents
                .Include(p => p.State)
                .ToList()
                .Select(Mapper.Map<Parent, ParentDTO>);
            return Ok(parentDto);
        }

        [HttpGet]
        public IHttpActionResult GetParent(int id)
        {
            var parent = _context.Parents.SingleOrDefault(c => c.ID == id);
            if (parent == null)
                return NotFound();
            return Ok(Mapper.Map<Parent, ParentDTO>(parent));
        }

        [HttpDelete]
        public IHttpActionResult DeleteParent(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var parentInDB = _context.Parents.SingleOrDefault(c => c.ID == id);

            if (parentInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Parents.Remove(parentInDB);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateParent(int id, ParentDTO parentDto)
        {

            var parentInDB = _context.Parents.SingleOrDefault(c => c.ID == id);

            if (parentInDB == null)
                NotFound();

            Mapper.Map(parentDto, parentInDB);
            _context.SaveChanges();

            return Ok(parentDto);
        }
    }
}

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
    public class StateController : ApiController
    {
        private ApplicationDbContext _context;

        public StateController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetStates()
        {
            var StateDto = _context.States
                .ToList()
                .Select(Mapper.Map<State, StateDTO>);
            return Ok(StateDto);
        }

        [HttpGet]
        public IHttpActionResult GetState(int id)
        {
            var State = _context.States.SingleOrDefault(c => c.ID == id);
            if (State == null)
                return NotFound();
            return Ok(Mapper.Map<State, StateDTO>(State));
        }
    }
}

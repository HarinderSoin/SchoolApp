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
    public class RoomsController : ApiController
    {
        private ApplicationDbContext _context;

        public RoomsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRoom(RoomDTO RoomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Room = Mapper.Map<RoomDTO, Room>(RoomDto);

            _context.Rooms.Add(Room);
            _context.SaveChanges();
            RoomDto.ID = Room.ID;
            return Created(new Uri(Request.RequestUri + "/" + RoomDto.ID), RoomDto);
        }

        [HttpGet]
        public IHttpActionResult GetRooms()
        {
            var RoomDto = _context.Rooms
                .ToList()
                .Select(Mapper.Map<Room, RoomDTO>);
            return Ok(RoomDto);
        }

        [HttpGet]
        public IHttpActionResult GetRoom(int id)
        {
            var Room = _context.Rooms.SingleOrDefault(c => c.ID == id);
            if (Room == null)
                return NotFound();
            return Ok(Mapper.Map<Room, RoomDTO>(Room));
        }

        [HttpDelete]
        public IHttpActionResult DeleteRoom(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var RoomInDB = _context.Rooms.SingleOrDefault(c => c.ID == id);

            if (RoomInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Rooms.Remove(RoomInDB);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateRoom(int id, RoomDTO RoomDto)
        {

            var RoomInDB = _context.Rooms.SingleOrDefault(c => c.ID == id);

            if (RoomInDB == null)
                NotFound();

            Mapper.Map(RoomDto, RoomInDB);
            _context.SaveChanges();

            return Ok(RoomDto);
        }
    }
}

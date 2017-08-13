using System;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using SchoolApp.DTO;
using SchoolApp.Exceptions;
using SchoolApp.Models;
using SchoolApp.Generic;

namespace SchoolApp.Controllers.API
{
    public class ParentController : ApiController
    {
        private ApplicationDbContext _context;
        GeneralExceptions generalExceptions = new GeneralExceptions();
        ParentExceptions parentExceptions = new ParentExceptions();
        string parentController = MethodBase.GetCurrentMethod().DeclaringType.Name;



        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ParentController()
        {
            _context = new ApplicationDbContext();
            string parentController = GetType().Name;
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        [System.Web.Http.HttpPost]

        public IHttpActionResult CreateParent(ParentDTO parentDto)
        {
            string methodName = new StackFrame(0).GetMethod().Name;
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            logger.Error("BadRequest: Invalid Model State");

            var userId = User.Identity.GetUserId();
            parentDto.UserId = User.Identity.GetUserId();

            //For Testing
            //var userId = "50dca3c2-6b22-4787-ba2b-091f58358253";
            //parentDto.UserId = userId;

            if (userId == null)
            {
                var user = parentDto.Parent1Name + " " + parentDto.Parent1LastName;

                generalExceptions.UserNotFoundError(user, parentController, methodName);
            }

            //try
            //{
                var parent = Mapper.Map<ParentDTO, Parent>(parentDto);

                _context.Parents.Add(parent);
                _context.SaveChanges();
                parentDto.ID = parent.ID;

            /*}
            catch (SqlException ex)
            {
                string str;
                str = "Source:" + ex.Source;
                str += "\n" + "Number:" + ex.Number.ToString();
                str += "\n" + "Message:" + ex.Message;
                str += "\n" + "Class:" + ex.Class.ToString();
                str += "\n" + "Procedure:" + ex.Procedure.ToString();
                str += "\n" + "Line Number:" + ex.LineNumber.ToString();
                str += "\n" + "Server:" + ex.Server.ToString();

                parentExceptions.ParentCatch(str, ex, parentController, methodName);
            }

            catch (DbEntityValidationException e)
            {
                
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"", eve.PropertyName, eve.Entry.CurrentValues.GetValue<object>(eve.PropertyName), eve.ErrorMessage);
                }
                var msg = "db" +parentDto.Parent1Name + " " + parentDto.Parent1LastName;
                parentExceptions.ParentCatch(msg, e, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg = parentDto.Parent1Name + " " + parentDto.Parent1LastName;
                parentExceptions.ParentCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();
                
            }*/

            return Created(new Uri(Request.RequestUri + "/" + parentDto.ID), parentDto);
        }
    

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetParents()
        {
            var userId = User.Identity.GetUserId();
            string methodName = new StackFrame(0).GetMethod().Name;

            try
            {
                var parentDto = _context.Parents
                    .Include(p => p.State)
                    .ToList()
                    .Select(Mapper.Map<Parent, ParentDTO>);
                return Ok(parentDto);
            }
            catch (SqlException ex)
            {
                string str;
                str = "Source:" + ex.Source;
                str += "\n" + "Number:" + ex.Number.ToString();
                str += "\n" + "Message:" + ex.Message;
                str += "\n" + "Class:" + ex.Class.ToString();
                str += "\n" + "Procedure:" + ex.Procedure.ToString();
                str += "\n" + "Line Number:" + ex.LineNumber.ToString();
                str += "\n" + "Server:" + ex.Server.ToString();

                parentExceptions.ParentCatch(str, ex, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg = "Error getting data from DB";
                parentExceptions.ParentCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();

            }
            return BadRequest();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetParent(int id)
        {
            string methodName = new StackFrame(0).GetMethod().Name;
            try
            {
                var parent = _context.Parents.SingleOrDefault(c => c.ID == id);

                if (parent == null)
                    return NotFound();
                return Ok(Mapper.Map<Parent, ParentDTO>(parent));
            }
            catch (SqlException ex)
            {
                string str;
                str = "Source:" + ex.Source;
                str += "\n" + "Number:" + ex.Number.ToString();
                str += "\n" + "Message:" + ex.Message;
                str += "\n" + "Class:" + ex.Class.ToString();
                str += "\n" + "Procedure:" + ex.Procedure.ToString();
                str += "\n" + "Line Number:" + ex.LineNumber.ToString();
                str += "\n" + "Server:" + ex.Server.ToString();

                parentExceptions.ParentCatch(str, ex, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg = "Error getting data from DB";
                parentExceptions.ParentCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();

            }
            return BadRequest();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteParent(int id)
        {
            string methodName = new StackFrame(0).GetMethod().Name;
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                logger.Error("BadRequest: Invalid Model State");
            try
            {
                var parentInDB = _context.Parents.SingleOrDefault(c => c.ID == id);

                if (parentInDB == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                _context.Parents.Remove(parentInDB);
                _context.SaveChanges();

                return Ok();
            }
            catch (SqlException ex)
            {
                string str;
                str = "Source:" + ex.Source;
                str += "\n" + "Number:" + ex.Number.ToString();
                str += "\n" + "Message:" + ex.Message;
                str += "\n" + "Class:" + ex.Class.ToString();
                str += "\n" + "Procedure:" + ex.Procedure.ToString();
                str += "\n" + "Line Number:" + ex.LineNumber.ToString();
                str += "\n" + "Server:" + ex.Server.ToString();

                parentExceptions.ParentCatch(str, ex, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg = "Error getting data from DB";
                parentExceptions.ParentCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();

            }
            return BadRequest();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateParent(int id, ParentDTO parentDto)
        {
            string methodName = new StackFrame(0).GetMethod().Name;

            try
            {
                var parentInDB = _context.Parents.SingleOrDefault(c => c.ID == id);

                if (parentInDB == null)
                    NotFound();

                Mapper.Map(parentDto, parentInDB);
                _context.SaveChanges();

                return Ok(parentDto);
            }
            catch (SqlException ex)
            {
                string str;
                str = "Source:" + ex.Source;
                str += "\n" + "Number:" + ex.Number.ToString();
                str += "\n" + "Message:" + ex.Message;
                str += "\n" + "Class:" + ex.Class.ToString();
                str += "\n" + "Procedure:" + ex.Procedure.ToString();
                str += "\n" + "Line Number:" + ex.LineNumber.ToString();
                str += "\n" + "Server:" + ex.Server.ToString();

                parentExceptions.ParentCatch(str, ex, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg = "Error getting data from DB";
                parentExceptions.ParentCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();

            }
            return BadRequest();
        }

    }
}

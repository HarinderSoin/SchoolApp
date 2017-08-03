using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using SchoolApp.DTO;
using SchoolApp.Exceptions;
using SchoolApp.Models;
using SchoolApp.Generic;



namespace SchoolApp.Controllers.API
{
    public class AcademicYearsController : ApiController
    { 
        private ApplicationDbContext _context;
        GeneralExceptions generalExceptions = new GeneralExceptions();
        AcademicYearExceptions ayExceptions = new AcademicYearExceptions();
        string parentController = MethodBase.GetCurrentMethod().DeclaringType.Name;

        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AcademicYearsController()
        {
            _context = new ApplicationDbContext();
        }


         [System.Web.Http.HttpPost]
        public IHttpActionResult CreateAcademicYear(AcademicYearDTO AcademicYearDto)
        {
            string methodName = new StackFrame(0).GetMethod().Name;
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            logger.Error("BadRequest: Invalid Model State");

            try
            {
                var academicYear = Mapper.Map<AcademicYearDTO, AcademicYear>(AcademicYearDto);

                _context.AcademicYears.Add(academicYear);
                _context.SaveChanges();
                AcademicYearDto.ID = academicYear.ID;
                return Created(new Uri(Request.RequestUri + "/" + AcademicYearDto.ID), AcademicYearDto);
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

                ayExceptions.AcademicYearCatch(str, ex, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg =AcademicYearDto.SchoolYear;
                ayExceptions.AcademicYearCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();

            }
            return BadRequest();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAcademicYears()
        {
            string methodName = new StackFrame(0).GetMethod().Name;
            try
            {
                var AcademicYearDto = _context.AcademicYears
                    .ToList()
                    .Select(Mapper.Map<AcademicYear, AcademicYearDTO>);
                return Ok(AcademicYearDto);
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

                ayExceptions.AcademicYearCatch(str, ex, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg = "No Data found for Academic Years";
                ayExceptions.AcademicYearCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();

            }
            return BadRequest();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAcademicYear(int id)
        {
            string methodName = new StackFrame(0).GetMethod().Name;
            try
            {
                var AcademicYear = _context.AcademicYears.SingleOrDefault(c => c.ID == id);
                if (AcademicYear == null)
                    return NotFound();
                return Ok(Mapper.Map<AcademicYear, AcademicYearDTO>(AcademicYear));
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

                ayExceptions.AcademicYearCatch(str, ex, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg = "No Data found for Academic Years";
                ayExceptions.AcademicYearCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();

            }
            return BadRequest();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteAcademicYear(int id)
        {
            string methodName = new StackFrame(0).GetMethod().Name;
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            logger.Error("BadRequest: Invalid Model State");

            try
            {
                var AcademicYearInDB = _context.AcademicYears.SingleOrDefault(c => c.ID == id);

                if (AcademicYearInDB == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                _context.AcademicYears.Remove(AcademicYearInDB);
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

                ayExceptions.AcademicYearCatch(str, ex, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg = "No Data found for Academic Years";
                ayExceptions.AcademicYearCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();

            }
            return BadRequest();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateAcademicYear(int id, AcademicYearDTO AcademicYearDto)
        {
            string methodName = new StackFrame(0).GetMethod().Name;
            try
            {
                var AcademicYearInDB = _context.AcademicYears.SingleOrDefault(c => c.ID == id);

                if (AcademicYearInDB == null)
                    NotFound();

                Mapper.Map(AcademicYearDto, AcademicYearInDB);
                _context.SaveChanges();

                return Ok(AcademicYearDto);
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

                ayExceptions.AcademicYearCatch(str, ex, parentController, methodName);
            }

            catch (Exception e)
            {
                var msg = "No Data found for Academic Years";
                ayExceptions.AcademicYearCatch(msg, e, parentController, methodName);
            }
            finally
            {
                this._context.Dispose();

            }
            return BadRequest();
        }
    }
}

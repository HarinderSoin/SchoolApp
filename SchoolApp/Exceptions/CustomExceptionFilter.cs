using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using log4net.Repository.Hierarchy;

namespace SchoolApp.Exceptions
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnException(HttpActionExecutedContext filterContext)
        {

            Exception ex = filterContext.Exception;
            logger.Error("Unhandled Exception",filterContext.Exception);
            

            var resp = filterContext.Exception.Message; 

            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(filterContext.Exception.Message),
                ReasonPhrase = filterContext.Exception.Message
            };

        throw new HttpResponseException(response);
  

        }
    }
}
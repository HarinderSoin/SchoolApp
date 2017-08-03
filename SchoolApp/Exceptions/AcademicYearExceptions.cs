using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SchoolApp.Exceptions
{
    public class AcademicYearExceptions
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void AcademicYearCatch(string data, Exception errorMessage, string apiController, string api)
        {

            logger.Error(apiController + ": " + api + " data: " + errorMessage.Message);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format(data + " : " + errorMessage.Message)),
                ReasonPhrase = "Error in Academic Year Controller"
            };
            throw new HttpResponseException(resp);
        }
    }
}
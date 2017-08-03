using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolApp.Exceptions
{
    public class GeneralExceptions
    {

        readonly log4net.ILog logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void UserNotFoundError(string userName, string apiController, string api)
        {

            logger.Error(apiController + ": " + api + " User Not Found: " + userName);
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("User Not Found: " + userName)),
                ReasonPhrase = "User Not found"
            };
            throw new HttpResponseException(resp);
        }
    }
}
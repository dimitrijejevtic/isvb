using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace isvb.dev.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AccessDenied()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
    public class ErrorAPIController : ApiController
    {
        public HttpResponseMessage AccessDenied()
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLab.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Exception()
        {
            throw new NullReferenceException();
        }
        // GET: Error
        public ActionResult NotFind()
        {
            return HttpNotFound();
        }
    }
}
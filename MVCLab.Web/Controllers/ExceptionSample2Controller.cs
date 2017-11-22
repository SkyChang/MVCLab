using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLab.Web.Controllers
{
    //[HandleError(ExceptionType = typeof(NullReferenceException), View = "NullReferenceException")]
    public class ExceptionSample2Controller : Controller
    {
        // GET: ExceptionSample2
        public ActionResult Exception()
        {
            throw new NullReferenceException();
        }

        public ActionResult Error()
        {
            return View("Error");
        }

        //customErrors mode="Off"
        protected override void OnException(ExceptionContext filterContext)
        {
            // 代表例外已經被處理
            filterContext.ExceptionHandled = true;

            //filterContext.Result = RedirectToAction("Error", "ExceptionSample2");

            // 或~
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/ExceptionSample2/Error.cshtml"
            };
        }
    }
}
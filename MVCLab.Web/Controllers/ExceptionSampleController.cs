using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLab.Web.Controllers
{

    public class ExceptionSampleController : Controller
    {
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "NullReferenceException")]
        //customErrors mode="On"
        public ActionResult Exception()
        {
            throw new NullReferenceException();
        }
    }
}
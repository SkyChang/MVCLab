using MVCLab.Domain.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLab.Web.Controllers
{
    public class LoginController : Controller
    {

        #region Login for FormCollection

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Lab
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection f)
        {
            if (f["UserName"] == "sky" && f["PW"] == "123")
            {
                return RedirectToAction("Success");
            }

            return RedirectToAction("Fail");

        }
        #endregion

        #region Login for Model

        // GET: Login
        public ActionResult IndexForModel()
        {
            return View();
        }

        //Lab
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexForModel(Customer customer)
        {
            if (customer.UserName == "sky" && customer.PW == "123")
            {
                return RedirectToAction("Success");
            }

            return RedirectToAction("Fail");

        }
        #endregion

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Fail()
        {
            return View();
        }
    }
}
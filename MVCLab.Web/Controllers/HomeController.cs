using MVCLab.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLab.Web
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return Content("Hello!!");
            //return File(Server.MapPath("~/bootcamp.png"), "image/png");
            //return File(Server.MapPath("~/bootcamp.png"), "image/png","測試.png");

            return View("Index");

            //return RedirectPermanent("http://www.yahoo.com.tw");
            //return Redirect("http://www.yahoo.com.tw");
            //return View("Index");
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            var aa = f["name"];
            return View();
        }

        public ActionResult Error404()
        {
            //return HttpNotFound(); //404
            //return new HttpUnauthorizedResult(); //401
            return new HttpStatusCodeResult(200, "Not Find");
        }

        public ActionResult HtmlHelp()
        {
            var adds = new List<string>();
            adds.Add("台北");
            adds.Add("台中");
            adds.Add("高雄");

            ViewBag.Adds = new SelectList(adds);

            ViewData["EncodeDemo"] = "<span>EncodeDemo</span>";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HtmlHelp(FormCollection f)
        {
            return RedirectToAction("HtmlHelp");
        }

        public ActionResult HtmlHelpFor()
        {
            var cust = new Customer();

            cust.Hide = "Hide";

            var adds = new List<string>();
            adds.Add("台北");
            adds.Add("台中");
            adds.Add("高雄");

            ViewBag.Adds = new SelectList(adds);

            ViewData["EncodeDemo"] = "<span>EncodeDemo</span>";

            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HtmlHelpFor(Customer cust)
        {
            return RedirectToAction("HtmlHelpFor");
        }
    }
}
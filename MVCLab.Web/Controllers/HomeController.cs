using MVCLab.Domain.CRM;
using MVCLab.Infrastructure.Data.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLab.Web
{
    public class HomeController : Controller
    {
        #region DemoResult
        
        
        public ActionResult Index()
        {
            @ViewData["Hello"] = "Hello";
            //return Content("Hello!!");
            //return File(Server.MapPath("~/bootcamp.png"), "image/png");
            //return File(Server.MapPath("~/bootcamp.png"), "image/png","測試.png");

            return View("Index");

            //return RedirectPermanent("http://www.yahoo.com.tw");
            //return Redirect("http://www.yahoo.com.tw");
            //return View("Index");
        }


        public ActionResult Now()
        {
            return Content(DateTime.Now.ToString());
        }

        public ActionResult Error404()
        {
            //eturn HttpNotFound("錯誤!!"); //404
            //return new HttpUnauthorizedResult(); //401
            return new HttpStatusCodeResult(200, "Not Find");
        }
        #endregion


        #region Demo FormCollection
        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            var aa = f["name"];
            return View();
        }
        #endregion


        #region Demo HTML Helper
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


        //Demo HTML Help Ajax
        public ActionResult HtmlHelpAjax()
        {
            var adds = new List<string>();
            adds.Add("台北");
            adds.Add("台中");
            adds.Add("高雄");

            ViewBag.Adds = new SelectList(adds);
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult HtmlHelpAjax(FormCollection f)
        {
            var id = f[1];
            return Content(id + "Success");
        }

        //Demo Html HelpFor

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


        //Demo Html HelpFor for EF

        public ActionResult HtmlHelpForEF()
        {
            var cust = new Customer();

            cust.Hide = "Hide";

            var adds = new List<string>();
            adds.Add("台北");
            adds.Add("台中");
            adds.Add("高雄");

            ViewBag.Adds = new SelectList(adds);

            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HtmlHelpForEF(Customer cust)
        {
            if (!ModelState.IsValid)
            {
                var adds = new List<string>();
                adds.Add("台北");
                adds.Add("台中");
                adds.Add("高雄");

                ViewBag.Adds = new SelectList(adds);

                return View(cust);
            }
            IUnitOfWork uow = new UnitOfWork();
            uow.Repository<Customer>().Insert(cust);
            uow.Save();
            return RedirectToAction("HtmlHelpForEF");
        }

        #endregion



        #region Demo Layout
        public ActionResult HaveLayout()
        {
            return View();
        }


        //Demo PartialView

        public ActionResult HavePartialView()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult NowPartial()
        {
            ViewBag.Now = DateTime.Now;
            return PartialView("_NowPartial");
        }
        #endregion


        #region Demo Web Api & AngularJS
        public ActionResult WebApi()
        {
            return View();
        }
        #endregion

    }
}
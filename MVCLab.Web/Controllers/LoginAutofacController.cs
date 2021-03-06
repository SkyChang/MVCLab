﻿using MVCLab.Domain.CRM;
using MVCLab.Infrastructure.Data.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLab.Web.Controllers
{
    public class LoginAutofacController : Controller
    {
        private IUnitOfWork _uow;

        public LoginAutofacController(IUnitOfWork unitOfWork) 
        {
            _uow = unitOfWork;
        }

        #region Login for Modal

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Lab
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Customer customer)
        {
            if (_uow.Repository<Customer>()
                .Get(c => c.UserName == customer.UserName && 
                    c.PW == customer.PW,null,"").Count() > 0 )
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
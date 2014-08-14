using MVCLab.Domain.CRM;
using MVCLab.Web;
using MVCLab.Web.Controllers;
using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using Xunit;

namespace MVCLab.Test
{

    public class LoginController_Test
    {
        [Fact]
        public void Login_Action_Success()
        {
            // arrange
            var controller = new LoginController();
            var f = new FormCollection();
            f.Add("UserName", "sky");
            f.Add("PW", "123");

            // act
            var result = controller.Index(f) as RedirectToRouteResult;

            // assert
            Assert.Equal("Success", result.RouteValues["action"]);
        }

        [Fact]
        public void Login_Action_Fail()
        {
            // arrange
            var controller = new LoginController();
            var f = new FormCollection();
            f.Add("UserName", "sky");
            f.Add("PW", "1233");

            // act
            var result = controller.Index(f) as RedirectToRouteResult;

            // assert
            Assert.Equal("Fail", result.RouteValues["action"]);
        }


        [Fact]
        public void LoginForModel_Action_Success()
        {
            // arrange
            var controller = new LoginController();
            var customer = new Customer() { UserName="sky",PW="123" };

            // act
            var result = controller.IndexForModel(customer) as RedirectToRouteResult;

            // assert
            Assert.Equal("Success", result.RouteValues["action"]);
        }

        [Fact]
        public void LoginForModel_Action_Fail()
        {
            // arrange
            var controller = new LoginController();
            var customer = new Customer() { UserName = "sky", PW = "1233" };

            // act
            var result = controller.IndexForModel(customer) as RedirectToRouteResult;

            // assert
            Assert.Equal("Fail", result.RouteValues["action"]);
        }
    }
}

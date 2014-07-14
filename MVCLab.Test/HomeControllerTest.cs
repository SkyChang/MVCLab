using MVCLab.Web;
using System;
using System.Web.Mvc;
using Xunit;

namespace UnitTestProject1
{

    public class HomeController_Test
    {
        [Fact]
        public void Index_Action_Test()
        {
            // arrange
            var controller = new HomeController();

            // act
            var result = controller.Index() as ViewResult;
            //var resultData = (Contact)result.ViewData.Model;

            // assert
            Assert.Equal("Index", result.ViewName);
        }
    }
}

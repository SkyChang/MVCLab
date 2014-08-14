using Moq;
using MVCLab.Domain.CRM;
using MVCLab.Infrastructure.Data.CRM;
using MVCLab.Web;
using MVCLab.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Xunit;

namespace MVCLab.Test
{

    public class LoginForDBController_Test
    {
        [Fact]
        public void Login_Action_Success()
        {
            // arrange
            var countries = new List<Customer> { new Customer { UserName = "sky", PW = "123" } };
            var queryableCountries = countries.AsQueryable();

            var mockUow = new Mock<IUnitOfWork>();

            mockUow.Setup(mu => mu.Repository<Customer>().Get(
                It.IsAny<Expression<Func<Customer, bool>>>(), null, ""))
                .Returns(queryableCountries);


            var controller = new LoginForDBController(mockUow.Object);
            var customer = new Customer { UserName="sky", PW="123" };

            // act
            var result = controller.Index(customer) as RedirectToRouteResult;

            // assert
            Assert.Equal("Success", result.RouteValues["action"]);
        }

        [Fact]
        public void Login_Action_Fail()
        {
            // arrange
            var countries = new List<Customer>();
            var queryableCountries = countries.AsQueryable();

            var mockUow = new Mock<IUnitOfWork>();

            mockUow.Setup(mu => mu.Repository<Customer>().Get(
                It.IsAny<Expression<Func<Customer, bool>>>(), null, ""))
                .Returns(queryableCountries);


            var controller = new LoginForDBController(mockUow.Object);
            var customer = new Customer { UserName = "sky", PW = "1233" };

            // act
            var result = controller.Index(customer) as RedirectToRouteResult;

            // assert
            Assert.Equal("Fail", result.RouteValues["action"]);
        }
    }
}

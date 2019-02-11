using System.Net;
using CustomerTransaction.Controllers;
using CustomerTransaction.Interfaces;
using CustomerTransaction.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CustomerTransactionTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var customerRepoMoq = new Mock<ICustomerRepository>();
            _customerController = new CustomerController(customerRepoMoq.Object);
        }

        [Test]
        public void GetCustomers_EmptyInputParameters_BadRequest()
        {
            var inquery = new Inquiry();

            IActionResult result = _customerController.GetCustomers(inquery);
            var badRequest = result as BadRequestObjectResult;

            Assert.IsNotNull(badRequest, "Request can not be null");
            Assert.IsInstanceOf<BadRequestObjectResult>(result, "The result must be BAD REQUEST");
        }

        private CustomerController _customerController;
    }
}
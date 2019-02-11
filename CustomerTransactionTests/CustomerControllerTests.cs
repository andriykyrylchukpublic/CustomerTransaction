using System;
using System.Collections.Generic;
using AutoMapper;
using CustomerTransaction.Controllers;
using CustomerTransaction.Interfaces;
using CustomerTransaction.Models;
using CustomerTransaction.SharedEntities.Models;
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
            _customerRepoMoq = new Mock<ICustomerRepository>();
            _mapperMoq = new Mock<IMapper>();
            _customerController = new CustomerController(_customerRepoMoq.Object, _mapperMoq.Object);
        }

        [Test]
        public void GetCustomers_EmptyInputParameters_BadRequest()
        {
            var inquery = new Inquiry();

            IActionResult result = _customerController.GetCustomers(inquery);
            var badRequest = result as BadRequestObjectResult;

            Assert.IsNotNull(badRequest);
            Assert.IsInstanceOf<BadRequestObjectResult>(badRequest, "The result must be BAD REQUEST");
        }

        [Test]
        public void GetCustomers_NoIdMuch_NotFound()
        {
            var inputData = new Inquiry
            {
                CustomerId = 0
            };
            _customerRepoMoq.Setup(r => r.GetCustomers(It.IsAny<RequestData>())).Returns(new List<Customer>());

            var customerController = new CustomerController(_customerRepoMoq.Object, _mapperMoq.Object);

            IActionResult result = _customerController.GetCustomers(inputData);
            var notFound = result as NotFoundResult;

            Assert.IsNotNull(notFound, "Request can not be null");
            Assert.IsInstanceOf<NotFoundResult>(notFound, "The result must be BAD REQUEST");
        }

        [Test]
        public void GetCustomers_ValidInput_Success()
        {
            var inquery = new Inquiry
            {
                CustomerId = 0
            };
            var validCustomer = new Customer();
            _customerRepoMoq.Setup(r => r.GetCustomers(It.IsAny<RequestData>())).Returns(new List<Customer> { validCustomer });

            IActionResult result = _customerController.GetCustomers(inquery);
            var success = result as OkObjectResult;

            Assert.IsNotNull(success, "Request can not be null");
            Assert.IsInstanceOf<OkObjectResult>(success, "Must be Ok 200");
        }

        [Test]
        public void GetCustomers_ValidInput_VaidCustomerResult()
        {
            var inquery = new Inquiry { CustomerId = 0 };
            var validCustomerCollection = new List<Customer> { new Customer() };
            var validCustomerDtoCollection = new List<CustomerOutputDto> { new CustomerOutputDto() };

            _customerRepoMoq.Setup(r => r.GetCustomers(It.IsAny<RequestData>())).Returns(validCustomerCollection);
            _mapperMoq.Setup(m => m.Map<IEnumerable<CustomerOutputDto>>(validCustomerCollection))
                .Returns(validCustomerDtoCollection);

            IActionResult result = _customerController.GetCustomers(inquery);
            var success = result as OkObjectResult;

            Assert.IsNotNull(success, "Request can not be null");
            Assert.AreEqual(validCustomerDtoCollection, success.Value);
        }

        private CustomerController _customerController;
        private Mock<ICustomerRepository> _customerRepoMoq;
        private Mock<IMapper> _mapperMoq;
    }
}
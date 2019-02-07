using System;
using System.Collections.Generic;
using AutoMapper;
using CustomerTransaction.Interfaces;
using CustomerTransaction.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerTransaction.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {      
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(Inquiry inquiry)
        {
            var customers = _customerService.GetCustomers(inquiry);
            return Ok(Mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        private readonly ICustomerService _customerService;
    }
}

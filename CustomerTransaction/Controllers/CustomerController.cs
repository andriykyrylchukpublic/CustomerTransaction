﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (String.IsNullOrEmpty(inquiry.CustomerId) && String.IsNullOrEmpty(inquiry.Email))
            {
                ModelState.AddModelError(nameof(Inquiry), "No inquiry criteria");
            }

            if (inquiry.CustomerId == String.Empty)
            {
                ModelState.AddModelError(nameof(Inquiry), "Invalid Customer ID");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customers = _customerService.GetCustomers(Mapper.Map<RequestData>(inquiry));

            if (!customers.Any())
            {
                return NotFound();
            }

            return Ok(Mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        private readonly ICustomerService _customerService;
    }
}

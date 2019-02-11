using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <returns>IEnumerable of CustomerOutputDto</returns>
        [HttpGet]
        public IActionResult Get(Inquiry inquiry)
        {
            if (inquiry is null)
            {
                return BadRequest();
            }

            if (inquiry.CustomerId == null && String.IsNullOrEmpty(inquiry.Email))
            {
                ModelState.AddModelError(nameof(Inquiry), "No inquiry criteria");
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

            return Ok(Mapper.Map<IEnumerable<CustomerOutputDto>>(customers));
        }

        private readonly ICustomerService _customerService;
    }
}

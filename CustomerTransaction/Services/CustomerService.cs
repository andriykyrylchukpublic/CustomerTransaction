using System;
using System.Collections.Generic;
using CustomerTransaction.Interfaces;
using CustomerTransaction.Models;

namespace CustomerTransaction.Services
{
    public class CustomerService: ICustomerService
    {     
        public CustomerService(ICustomerRepository repo)
        {
            _customerRepository = repo;
        }
        public IEnumerable<Customer> GetCustomers(Inquiry inquiry)
        {
            return _customerRepository.GetCustomers(inquiry);
        }

        private readonly ICustomerRepository _customerRepository;
    }
}

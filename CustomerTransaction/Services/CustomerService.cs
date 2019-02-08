using System.Collections.Generic;
using CustomerTransaction.Interfaces;
using CustomerTransaction.Models;
using CustomerTransaction.SharedEntities.Models;

namespace CustomerTransaction.Services
{
    public class CustomerService: ICustomerService
    {     
        public CustomerService(ICustomerRepository repo)
        {
            _customerRepository = repo;
        }
        public IEnumerable<Customer> GetCustomers(RequestData inquiry)
        {
            return _customerRepository.GetCustomers(inquiry);
        }

        private readonly ICustomerRepository _customerRepository;
    }
}

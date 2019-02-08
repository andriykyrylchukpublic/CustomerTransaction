using System;
using System.Collections.Generic;
using CustomerTransaction.Models;
using CustomerTransaction.SharedEntities.Models;

namespace CustomerTransaction.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers(RequestData inquiry);
    }
}

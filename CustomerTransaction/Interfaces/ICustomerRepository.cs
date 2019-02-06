using System;
using System.Collections.Generic;
using CustomerTransaction.Models;

namespace CustomerTransaction.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers(Inquiry inquiry);
    }
}

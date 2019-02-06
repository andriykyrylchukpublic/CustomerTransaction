
using System.Collections.Generic;
using CustomerTransaction.Models;

namespace CustomerTransaction.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers(Inquiry inquiry);
    }
}

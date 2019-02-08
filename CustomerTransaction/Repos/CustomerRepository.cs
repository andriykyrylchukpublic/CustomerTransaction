using System;
using System.Collections.Generic;
using System.Linq;
using CustomerTransaction.Data;
using CustomerTransaction.Interfaces;
using CustomerTransaction.Models;
using CustomerTransaction.SharedEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerTransaction.Repos
{
    public class CustomerRepository:ICustomerRepository
    {      
        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers(RequestData inquiry)
        {
            IQueryable<Customer> customers = 
                _context.Customers.Include(c => c.Transactions);


            if (!(inquiry.CustomerId is null))
            {
                customers = customers.Where(c => c.CustomerId == inquiry.CustomerId);
            }

            if (!String.IsNullOrEmpty(inquiry.Email))
            {
                customers = customers.Where(c =>
                    String.Equals(c.Email, inquiry.Email, StringComparison.InvariantCulture));
            }
            
            var customersWithSortedTransactions = customers.Select(c => new Customer
            {
                Transactions = c.Transactions.OrderByDescending(t => t.Date).Take(5),
                CustomerId = c.CustomerId,
                Email = c.Email,
                Mobile = c.Mobile,
                Name =  c.Name
            });

            return customersWithSortedTransactions;
        }

        private readonly CustomerContext _context;
    }
}




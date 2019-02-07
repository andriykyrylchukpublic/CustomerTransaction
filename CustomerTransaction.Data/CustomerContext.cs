using System;
using CustomerTransaction.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerTransaction.Data
{
    public class CustomerContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

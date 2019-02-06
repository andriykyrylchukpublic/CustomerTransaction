using System;
using System.Collections.Generic;
using System.Linq;
using CustomerTransaction.Interfaces;
using CustomerTransaction.Models;

namespace CustomerTransaction.Repos
{
    public class InMemoryCustomerRepository:ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomers(Inquiry inquiry)
        {
            return CreateCustomer().Where(c =>
                c.CustomerId == inquiry.CustomerId || String.Equals(c.Email, inquiry.Email, StringComparison.InvariantCulture));
        }

        private static IEnumerable<Customer> CreateCustomer()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Email = "geralt@thewithcer.com",
                    CustomerId = 0,
                    Mobile = 0000000000,
                    Name = "Geralt of Rivia",
                    Transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Date = DateTime.MinValue,
                            Id = 1234567890,
                            Amount = 1111.00m,
                            Currency = "RIV",
                            Status = Status.Success,                      
                        }
                    }
                },
                new Customer
                {
                    Email = "cirilla@thewithcer.com",
                    CustomerId = 1,
                    Mobile = 0000000001,
                    Name = "Cirilla",
                    Transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Date = DateTime.MinValue,
                            Id = 1234567890,
                            Amount = 1111.00m,
                            Currency = "CIN",
                            Status = Status.Failed,
                        }
                    }
                },                
                new Customer
                {
                    Email = "yenifer@thewithcer.com",
                    CustomerId = 3,
                    Mobile = 0000000003,
                    Name = "Yenifer of Vengerberg",
                    Transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Date = DateTime.MinValue,
                            Id = 1234567890,
                            Amount = 1111.00m,
                            Currency = "VEN",
                            Status = Status.Canceled,
                        }
                    }
                }
            };
        }
    }
}

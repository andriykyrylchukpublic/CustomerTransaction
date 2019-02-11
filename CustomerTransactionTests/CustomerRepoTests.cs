using System;
using System.Collections.Generic;
using System.Linq;
using CustomerTransaction.Data;
using CustomerTransaction.Models;
using CustomerTransaction.Repos;
using CustomerTransaction.SharedEntities.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CustomerTransactionTests
{
    public class CustomerRepoTests
    {
        [SetUp]
        public void Setup()
        {
            SetUpContext();
        }

        [Test]
        public void GetCustomers_ValidId_CustomersCollectionWithCorespondingCustomerReturned()
        {
            const Int64 validId = 10000000000;
            var requestData = new RequestData
            {
                CustomerId = validId
            };
            var repo = new CustomerRepository(_dbContext);

            var result = repo.GetCustomers(requestData);

            Assert.IsNotNull(result, "Response can not be null");
            Assert.AreEqual(validId, result.FirstOrDefault()?.CustomerId, "Ids doesen't match");
        }

        [Test]
        public void GetCustomers_ValidEmail_CustomersCollectionWithCorespondingCustomerReturned()
        {
            const String validEmail = "geralt@thewithcer.com";
            var requestData = new RequestData
            {
                Email = validEmail
            };
            var repo = new CustomerRepository(_dbContext);

            var result = repo.GetCustomers(requestData);

            Assert.IsNotNull(result, "Response can not be null");
            Assert.AreEqual(validEmail, result.FirstOrDefault()?.Email, "Emails doesen't match");
        }

        [Test]
        public void GetCustomers_ValidEmailAndValidId_CustomersCollectionWithCorespondingCustomerReturned()
        {
            const String validEmail = "geralt@thewithcer.com";
            const Int64 validId = 10000000000;
            var requestData = new RequestData
            {
                Email = validEmail,
                CustomerId = validId
            };
            var repo = new CustomerRepository(_dbContext);

            var result = repo.GetCustomers(requestData).ToList();

            Assert.IsNotNull(result, "Response can not be null");
            Assert.IsTrue(result.Any());
            Assert.AreEqual(validEmail, result.FirstOrDefault()?.Email, "Emails doesen't match");
            Assert.AreEqual(validId, result.FirstOrDefault()?.CustomerId, "Ids doesen't match");
        }

        [Test]
        public void GetCustomers_EmialDoesNotMatch_EmptyCollectionReturned()
        {
            const String noSuchEmail = "noSuchEmail@thewithcer.com";
            var requestData = new RequestData
            {
                Email = noSuchEmail
            };
            var repo = new CustomerRepository(_dbContext);

            var result = repo.GetCustomers(requestData);

            Assert.IsNotNull(result, "Response can not be null");
            Assert.IsFalse(result.Any());
        }

        [Test]
        public void GetCustomers_IdDoesNotMatch_EmptyCollectionReturned()
        {
            const Int64 idNotMached = 0;
            var requestData = new RequestData
            {
                CustomerId = idNotMached
            };
            var repo = new CustomerRepository(_dbContext);

            var result = repo.GetCustomers(requestData);

            Assert.IsNotNull(result, "Response can not be null");
            Assert.IsFalse(result.Any());
        }

        [Test]
        public void GetCustomers_ValidCustomer_FiveTransactions()
        {
            const String validEmail = "geralt@thewithcer.com";
            const Int64 validId = 10000000000;
            var requestData = new RequestData
            {
                Email = validEmail,
                CustomerId = validId
            };
            var repo = new CustomerRepository(_dbContext);

            var result = repo.GetCustomers(requestData).ToList();

            Assert.IsNotNull(result, "Response can not be null");
            Assert.AreEqual(5, result.FirstOrDefault()?.Transactions.Count());
        }


        private void SetUpContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
            optionsBuilder.UseInMemoryDatabase("MyDatabase");
            _dbContext = new CustomerContext(optionsBuilder.Options);
            var testCustomers = GetCutomerList();

            if (!_dbContext.Customers.Any())
            {
                testCustomers.ForEach(c => _dbContext.Customers.Add(c));
                _dbContext.SaveChanges();
            }
        }

        private static List<Customer> GetCutomerList()
        {
             return new List<Customer>
            {
                new Customer
                {
                    Email = "geralt@thewithcer.com",
                    CustomerId = 10000000000,
                    Mobile = 10000000000,
                    Name = "Geralt of Rivia",
                    Transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Date = DateTime.MinValue,
                            Amount = 1.00m,
                            Currency = "RIV",
                            Status = Status.Success,                      
                        },
                        new Transaction
                        {
                            Date = DateTime.MinValue.AddDays(1),
                            Amount = 2.00m,
                            Currency = "RIV",
                            Status = Status.Canceled,                      
                        },
                        new Transaction
                        {
                            Date = DateTime.MinValue.AddDays(2),
                            Amount = 3.00m,
                            Currency = "RIV",
                            Status = Status.Success,                      
                        },
                        new Transaction
                        {
                            Date = DateTime.MinValue.AddDays(3),
                            Amount = 4.00m,
                            Currency = "RIV",
                            Status = Status.Canceled,                      
                        },
                        new Transaction
                        {
                            Date = DateTime.MinValue.AddDays(4),
                            Amount = 5.00m,
                            Currency = "RIV",
                            Status = Status.Failed,                      
                        },
                        new Transaction
                        {
                            Date = DateTime.MinValue.AddDays(5),
                            Amount = 6.00m,
                            Currency = "RIV",
                            Status = Status.Success,                      
                        }
                    }
                },
                new Customer
                {
                    Email = "cirilla@thewithcer.com",
                    CustomerId = 1000000001,
                    Mobile = 1000000001,
                    Name = "Cirilla",
                    Transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Date = DateTime.MinValue,
                            Amount = 7.00m,
                            Currency = "CIN",
                            Status = Status.Failed,
                        }
                    }
                },                
                new Customer
                {
                    Email = "yenifer@thewithcer.com",
                    CustomerId = 1000000002,
                    Mobile = 1000000002,
                    Name = "Yenifer of Vengerberg",
                    Transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            Date = DateTime.MinValue,
                            Amount = 8.00m,
                            Currency = "VEN",
                            Status = Status.Canceled,
                        }
                    }
                }
            };
        }

        private CustomerContext _dbContext;
    }
}

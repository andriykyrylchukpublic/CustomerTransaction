using System;
using System.Collections.Generic;

namespace CustomerTransaction.SharedEntities.Models
{
    public class Customer
    {
        public Int64 CustomerId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public Int64 Mobile { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}

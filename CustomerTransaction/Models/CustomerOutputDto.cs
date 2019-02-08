using System;
using System.Collections.Generic;

namespace CustomerTransaction.Models
{
    public class CustomerOutputDto
    {
        public Int64 CustomerId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}

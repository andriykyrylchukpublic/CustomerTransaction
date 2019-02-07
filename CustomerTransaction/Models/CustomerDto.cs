using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace CustomerTransaction.Models
{
    public class CustomerDto
    {
        public Int32 CustomerId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public Int32 Mobile { get; set; }
        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}

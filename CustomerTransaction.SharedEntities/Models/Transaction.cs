using System;

namespace CustomerTransaction.SharedEntities.Models
{
    public class Transaction
    {
        public Int32 Id { get; set; }
        public Int32 CustomerId { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public String Currency { get; set; }
        public Status Status { get; set; }
    }
}
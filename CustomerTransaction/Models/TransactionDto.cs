using System;

namespace CustomerTransaction.Models
{
    public class TransactionDto
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public String Currency { get; set; }
        public String Status { get; set; }
    }
}

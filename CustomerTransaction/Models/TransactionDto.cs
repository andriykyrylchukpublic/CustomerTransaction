using System;
using Newtonsoft.Json;

namespace CustomerTransaction.Models
{
    public class TransactionDto
    {
        public Int32 Id { get; set; }
        [JsonConverter(typeof(CustomDateTimeFormater))]
        public DateTime Date { get; set; }
        public String Amount { get; set; }
        public String Currency { get; set; }
        public String Status { get; set; }
    }
}

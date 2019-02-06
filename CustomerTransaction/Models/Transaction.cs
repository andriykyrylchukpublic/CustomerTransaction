﻿using System;

namespace CustomerTransaction.Models
{
    public class Transaction
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public String Currency { get; set; }
        public Status Status { get; set; }
    }
}
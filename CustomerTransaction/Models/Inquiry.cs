using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerTransaction.Models
{
    public class Inquiry
    {
        [Range(1,9999999999, ErrorMessage = "Invalid Customer ID")]
        public Int64? CustomerId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [MaxLength(25, ErrorMessage = "Invalid Email")]
        public String Email { get; set; }
    }
}

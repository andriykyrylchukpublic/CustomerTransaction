using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerTransaction.Models
{
    public class Inquiry
    {
        [RegularExpression("^(\\d{1,10})$", ErrorMessage = "Invalid Customer ID")]
        public String CustomerId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [MaxLength(25, ErrorMessage = "Invalid Email")]
        public String Email { get; set; }
    }
}

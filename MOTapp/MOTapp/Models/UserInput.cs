﻿using System.ComponentModel.DataAnnotations;

namespace MotApp.Models
{
    public class UserInput
    {
        [Required]
        [RegularExpression(@"^([A-Z]{3}\s?(\d{3}|\d{2}|d{1})\s?[A-Z])|([A-Z]\s?(\d{3}|\d{2}|\d{1})\s?[A-Z]{3})|(([A-HK-PRSVWY][A-HJ-PR-Y])\s?([0][2-9]|[1-9][0-9])\s?[A-HJ-PR-Z]{3})$", ErrorMessage = "Invalid UK Vehicle Registration Number entered.")]
        public required string registrationNumber { get; set; }
    }
}

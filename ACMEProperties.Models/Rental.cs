using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ACMEProperties.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Rental Period")]
        public int DurationInMonths { get; set; }
    }
}

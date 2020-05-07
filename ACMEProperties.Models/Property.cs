using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACMEProperties.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Property Name")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Display(Name = "Description")]
        public string LongDesc { get; set; }

        [Required]
        [Display(Name = "Number of Rooms")]
        public int NumberOfRooms { get; set; }

        [Required]
        public int Bathrooms { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Rental")]
        public int RentalId { get; set; }

        [ForeignKey("RentalId")]
        public Rental Rental { get; set; }

    }
}

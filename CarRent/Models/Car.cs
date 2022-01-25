using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Car
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Make { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Model { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Trim { get; set; }

        [Required]
        public string Vin { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Millage { get; set; }
      
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

       
    }
}

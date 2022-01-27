using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        /*public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }


        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Typ Typ { get; set; }*/

    }

}

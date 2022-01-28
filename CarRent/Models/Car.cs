using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarRent.Models
{
    public class Car
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$",ErrorMessage ="Pls provide only Letters. First must be upper case")]
        [StringLength(60, MinimumLength = 1)]
        [Required(ErrorMessage = "Wrong Make Name")]
        public string Make { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+[0-9]*$", ErrorMessage = "Pls provide only Letters. First must be upper case")]
        [StringLength(60, MinimumLength = 1)]
        [Required(ErrorMessage = "Wrong Model Name")]
        public string Model { get; set; }

        [Required]
        public string Trim { get; set; }

        [Required(ErrorMessage = "Wrong VIN Number")]
        [RegularExpression(@"^[(A-H|J-N|P|R-Z|0-9)]{17}", ErrorMessage ="Pls provide correct VIN number")]
        
        public string Vin { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Wrong Millage")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only numbers are accepted")]
        public string Millage { get; set; }
      
        
        [Required(ErrorMessage = "Price required")]
        [RegularExpression(@"^\d+(,\d{1,2})?$", ErrorMessage = "Pls provide price in format '$,$' ")]
        public string Price { get; set; }

        
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

       


        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public Typ Typ { get; set; }

    }

}

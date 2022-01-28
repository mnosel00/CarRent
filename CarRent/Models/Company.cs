using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class Company
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Pls provide only Letters. First must be upper case")]
        [StringLength(60, MinimumLength = 1)]
        [Required(ErrorMessage = "Wrong Make Name")]
        public string Name { get; set; }

        
    }
}

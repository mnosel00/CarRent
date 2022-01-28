using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Typ
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Pls provide only Letters. First must be upper case")]
        [StringLength(60, MinimumLength = 1)]
        [Required(ErrorMessage = "Wrong Make Name")]
        public string Undercarriage { get; set; }
    }
}

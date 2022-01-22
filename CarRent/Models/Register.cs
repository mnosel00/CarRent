using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and Confirm Password are diffrent")]
        public string ConfirmPassword { get; set; }

    }
}

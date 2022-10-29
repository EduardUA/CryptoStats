#nullable disable

using System.ComponentModel.DataAnnotations;

namespace CryptoStats.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }


        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
        
    }
}

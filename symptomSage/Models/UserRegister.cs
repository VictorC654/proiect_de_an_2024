using System.ComponentModel.DataAnnotations;

namespace symptomSage.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Introduceti Username")]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username-ul nu poate fi mai lung de 20 caractere!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Introduce-ti adresa de email")]
        [EmailAddress]
        [Display(Name = "Adresa de email")]
        [StringLength(30)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Introduce-ți o adresă de email validă.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduceti parola")]
        [DataType(DataType.Password)]   
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Parola nu poate fi mai scurta de 8 caractere")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmati parola")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Parola si parola confirmata nu corespund!")]
        public string ConfirmPassword { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace symptomSage.Models
{
    public class UserLogin
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string Credential { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
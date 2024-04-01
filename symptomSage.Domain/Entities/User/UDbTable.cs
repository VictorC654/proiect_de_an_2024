using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace symptomSage.Domain.Entities.User
{ 
    public class UDbTable
    {
        // Id Setter
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        
        // Username validation
        [Required]
        [Display(Name = "Username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Numele tau nu poate fi mai mare decat 30 de caractere.")]
        
        public string Username { get; set; }
        
        // Password validation
        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Parola nu poate fi mai scurta decat 8 caractere")]
        
        public string Password { get; set; }

        // Email validation
        [Required]
        [Display(Name = "Email address")]
        [StringLength(30)]

        public string Email { get; set; }
        
        // Time
        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }
        
        // Ip
        [StringLength(30)]
        public string LastIp { get; set; }
        
        // Role [User or admin]
        // public URole Level { get; set; }
    }
}
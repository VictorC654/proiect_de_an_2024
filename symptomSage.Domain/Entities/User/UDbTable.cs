using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using symptomSage.Domain.Enums;

namespace symptomSage.Domain.Entities.User
{ 
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name cannot be longer that 20 characters.")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password cannot be shorter that 8 characters.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email adress")]
        [StringLength(30)]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public Nullable<DateTime> LastLogin { get; set; }

        [StringLength(30)]
        public string LasIp { get; set; }

        [Required]
        public URole Level { get; set; }

        [DataType(DataType.DateTime)]
        public Nullable<DateTime> RegisterDate { get; set; }
    }
}
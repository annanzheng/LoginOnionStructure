using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }

        [Display(Name = "UserName: ")]
        [Required(ErrorMessage = "UserName is required!")]
        public string username { get; set; }

        [Display(Name = "Email: ")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format!")]
        public string email { get; set; }

        [Display(Name = "Password: ")]
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters!")]
        public string password { get; set; }

        [Display(Name = "Confirmed Password: ")]
        [Required]
        [Compare("password", ErrorMessage = "Passwords do not match!")]
        public string confirmedPassword { get; set; }
    }
}

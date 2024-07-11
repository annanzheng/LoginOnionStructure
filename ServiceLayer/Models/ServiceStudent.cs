using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Models
{
    public class ServiceStudent
    {
        public int userID { get; set; }

        [Display(Name = "UserName: ")]
        [Required(ErrorMessage = "UserName is required!")]
        public string username { get; set; }

        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid email format!")]
        public string email { get; set; }

        [Display(Name = "Password: ")]
        [Required(ErrorMessage = "Password is required!")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters!")]
        public string password { get; set; }

        [Display(Name = "Confirmed Password: ")]
        [Required(ErrorMessage = "Confirm Password is required!")]
        [Compare("password", ErrorMessage = "Passwords do not match!")]
        public string confirmedPassword { get; set; }
    }
}

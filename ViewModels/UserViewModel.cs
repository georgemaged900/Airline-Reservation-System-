using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
   public class UserViewModel
    {
            
        [Required(ErrorMessage = "Please Enter User First Name")]
        [Display(Name = "First Name:")] // Display First Name UI
        public string Firstname { get; set; }


        [Required(ErrorMessage = "Please Enter User Last Name")]
        [Display(Name = "Last Name:")] // Display Last Name UI
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please Enter your email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")] // Display Email UI
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Please Enter a Valid User ID")]
        [StringLength(100,MinimumLength = 5)]
        [Display(Name = "User ID:")] // Display User ID UI
        public string User_ID { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Provide a correct password.")]
        [Display(Name = "Password:")] // Display Password UI
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Your password and confirm password don’t match")]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }


        [Display(Name = "Address:")] // Display Address UI
        public string Address { get; set; }

        public Nullable<decimal> Phone { get; set; }


    }
}

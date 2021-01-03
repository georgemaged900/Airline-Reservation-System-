using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class StaffViewModel
    {

        [Required(ErrorMessage = "Please Enter a Valid User ID")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "User ID:")] // Display User ID UI
        public string Staff_ID { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Provide a correct password.")]
        [Display(Name = "Password:")] // Display Password UI
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter User First Name")]
        [Display(Name = "First Name:")] // Display First Name UI
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please Enter User Last Name")]
        [Display(Name = "Last Name:")] // Display Last Name UI
        public string Lastname { get; set; }

    }
}

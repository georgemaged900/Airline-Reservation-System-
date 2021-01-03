using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebApplication2.ViewModels
{
   public class BookFlightViewModel
    {

        [Required(ErrorMessage = "Please Enter Flight Number")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Flight Number")] 
        public string Flight_Number { get; set; }

        [Required(ErrorMessage = "Please Enter a Valid User ID")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "User ID:")]
        public string User_ID { get; set; }

        [Required(ErrorMessage = "Please Enter a Valid Arrival Time")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Arrival Time:")]
        public Nullable<System.TimeSpan> Arrival_Time { get; set; }

        [Required(ErrorMessage = "Please Enter a Valid Arrival Time")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Arrival Date:")]
        public Nullable<System.DateTime> Arrival_Date { get; set; }

        [Required(ErrorMessage = "Please Enter a Valid Departure Date")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Departure Date:")]
        public Nullable<System.DateTime> Departure_Date { get; set; }

        [Required(ErrorMessage = "Please Enter a Valid Departure Time")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Departure Time:")]
        public Nullable<System.TimeSpan> Departure_Time { get; set; }

        [Required(ErrorMessage = "Please Enter a Valid Destination")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Destination:")]
        public string Destination_ { get; set; }

       
        [Display(Name = "Number of passengers s: 100:")]
        public Nullable<int> Number_of_passengers { get; set; }

    }
}

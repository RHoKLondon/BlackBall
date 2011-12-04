using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BlackBall.Models
{
    public class InflowItem : IValidatableObject
    {
        public InflowItem()
        {
            this.Amount = 0;
            this.DayOfMonth = 1;
        }

        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        [Display(Name="Name of the item (e.g. Job Seakers Allowance)")]
        public string Name { get; set; }

        [Required(ErrorMessage="Amount is required")]
        [Display(Name="Amount:")]
        public double Amount { get; set; }

        [Required]
        [Display(Name = "Monthly payment?")]
        public bool Monthly { get; set; }

        [Required(ErrorMessage = "You must specify when the money comes in")]
        [Display(Name = "Day of month (if a monthly payment):")]
        public int DayOfMonth { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (this.DayOfMonth < 0 || this.DayOfMonth > 28)
            {
                yield return new ValidationResult("Date must be between 1 and 28", new string[] { "DayOfMonth" });
            }
        }
    }
}

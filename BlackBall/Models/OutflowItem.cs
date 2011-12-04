using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlackBall.Models
{
    public class OutflowItem : IValidatableObject
    {
        public OutflowItem()
        {
            this.AmountDue = 0;
            this.AmountOwed = 0;
            this.DayOfMonth = 1;
        }

        public int Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        [Display(Name = "Name of the item (e.g. British Gas)")]
        public string Name { get; set; }

        [Display(Name="Optional notes (e.g. phone number or customer reference):")]
        public string Notes { get; set; }

        [Required(ErrorMessage="Amount due is required")]
        [Display(Name = "Amount due:")]
        public double AmountDue { get; set; }

        [Required(ErrorMessage="Amount owed is required")]
        [Display(Name = "Amount owed:")]
        public double AmountOwed { get; set; }

        [Required]
        [Display(Name="High priority?")]
        public bool HighPriority { get; set; }

        [Required]
        [Display(Name="Monthly payment?")]
        public bool Monthly { get; set; }

        [Required(ErrorMessage="You must specify when the payment is due")]
        [Display(Name="Day of month (if a monthly payment):")]
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

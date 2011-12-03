using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlackBall.Models
{
    public class OutflowItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }

        public string Notes { get; set; }

        [Required(ErrorMessage="Amount due is required")]
        public double AmountDue { get; set; }

        [Required(ErrorMessage="Amount owed is required")]
        public double AmountOwed { get; set; }

        [Required]
        public bool HighPriority { get; set; }

        [Required]
        public bool Recurring { get; set; }

        public virtual RecurrencePattern RecurrencePattern { get; set; }
    }
}

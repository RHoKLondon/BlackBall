using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlackBall.Models
{
    public class InflowItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage="Amount is required")]
        public double Amount { get; set; }

        [Required]
        public bool Recurring { get; set; }

        public virtual RecurrencePattern RecurrencePattern { get; set; }
    }
}

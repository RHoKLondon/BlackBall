using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackBall.Models
{
    public class OutflowItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public double AmountDue { get; set; }
        public double AmountOwed { get; set; }
        public bool HighPriority { get; set; }
        public bool Recurring { get; set; }
        public virtual RecurrencePattern RecurrencePattern { get; set; }
    }
}

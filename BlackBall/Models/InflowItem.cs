using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackBall.Models
{
    public class InflowItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public bool Recurring { get; set; }
        public virtual RecurrencePattern RecurrencePattern { get; set; }
    }
}

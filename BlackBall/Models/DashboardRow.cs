using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackBall.Models
{
    public class DashboardRow
    {
        public int Date { get; set; }
        public double Inflow { get; set; }
        public double Outflow { get; set; }
        public double CurrentStatus { get; set; }
    }
}

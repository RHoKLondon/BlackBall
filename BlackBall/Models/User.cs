using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlackBall.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage="Email address is required")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$", ErrorMessage="Please enter a valid email address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage="Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage="Mobile phone number is required")]
        public string MobilePhoneNumber { get; set; }

        public virtual ICollection<InflowItem> Inflow { get; set; }
        public virtual ICollection<OutflowItem> Outflow { get; set; }

        public IEnumerable<dynamic> GetInflowAndOutflow()
        {
            var data = new List<DashboardRow>();
            foreach (InflowItem i in this.Inflow)
            {
                data.Add(new DashboardRow { Date = i.DayOfMonth, Inflow=i.Amount, Outflow=0, CurrentStatus=0 });
            }
            foreach (OutflowItem o in this.Outflow)
            {
                data.Add(new DashboardRow { Date = o.DayOfMonth, Inflow = 0, Outflow = o.AmountDue, CurrentStatus = 0 });
            }

            data = data.OrderBy(x => x.Date).ToList();

            double total = 0.0;
            foreach (DashboardRow d in data)
            {
                total += d.Inflow - d.Outflow;
                d.CurrentStatus = total;
            }

            return data;
        }
    }
}

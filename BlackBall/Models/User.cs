using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackBall.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string MobilePhoneNumber { get; set; }
        public virtual ICollection<InflowItem> Inflow { get; set; }
        public virtual ICollection<OutflowItem> Outflow { get; set; }
    }
}

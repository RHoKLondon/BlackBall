using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlackBall.Models
{
    public class BlackBallDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<InflowItem> Inflow { get; set; }
        public DbSet<OutflowItem> Outflow { get; set; }
    }
}

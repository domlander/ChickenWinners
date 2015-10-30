using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChickenWinners.Models
{
    public class ResultsDbContext : DbContext
    {
        public DbSet <Fixture> Fixtures { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChickenWinners.Models
{
    public class LeaguePlayer
    {
        public int Id { get; set; }
        public virtual League League { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
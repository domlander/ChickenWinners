using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChickenWinners.Models
{
    // Each competition will have a League
    public class League
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public LeagueState State { get; set; }

        public Sport Sport { get; set; }

        public int StartWeek { get; set; } // 1 - 38 if Premier League

        public virtual ICollection<LeaguePlayer> LeaguePlayers { get; set; }
    }

}
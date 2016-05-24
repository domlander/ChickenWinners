using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChickenWinners.Models
{
    public class SportLeague
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Team> Teams { get; set; }
    }
}
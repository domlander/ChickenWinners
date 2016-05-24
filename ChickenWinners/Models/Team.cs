using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChickenWinners.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Badge { get; set; }
        public int League { get; set; }
    }
}
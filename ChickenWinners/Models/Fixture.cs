using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChickenWinners.Models
{
    [Table("Fixture")]
    public class Fixture
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Home Team")]
        public Team HomeTeamId { get; set; }

        [Display(Name="Away Team")]
        public Team AwayTeamId { get; set; }

        [Display(Name = "")]
        public int? HomeGoals { get; set; }

        [Display(Name = "")]
        public int? AwayGoals { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public int Week { get; set; }
    }
}
namespace ChickenWinners.ViewModels
{
    using ChickenWinners.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MyLeaguesViewModel
    {
        [Required(ErrorMessage = "Please enter a joining code.")]
        [Display(Name = "Joining Code")]
        public int Id { get; set; }
    
        public string Name { get; set; }

        public LeagueState State { get; set; }

        public Sport Sport { get; set; }

        public int StartWeek { get; set; }
    }
}
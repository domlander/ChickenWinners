namespace ChickenWinners.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using ChickenWinners.Models;

    public class CreateGameViewModel
    {
        [Required(ErrorMessage = "Please enter a name for the league.")]
        [Display(Name = "League name")]
        [StringLength(32, ErrorMessage="League name cannot be longer than 32 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start week")]
        public int StartWeek { get; set; }

        [Required]
        [Display(Name = "Sport")]
        public int Sport { get; set; }

        public IEnumerable<Sport> Sports { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChickenWinners.Models
{
    public enum Team
    {
        [Display(Name = "Arsenal")]
        Arsenal,
        [Display(Name = "Aston Villa")]
        AstonVilla,
        [Display(Name = "Bournemouth")]
        Bournemouth,
        [Display(Name = "Chelsea")]
        Chelsea,
        [Display(Name = "Crystal Palace")]
        CrystalPalace,
        [Display(Name = "Everton")]
        Everton,
        [Display(Name = "Leicester")]
        Leicester,
        [Display(Name = "Liverpool")]
        Liverpool,
        [Display(Name = "Manchester City")]
        ManchesterCity,
        [Display(Name = "Manchester United")]
        ManchesterUnited,
        [Display(Name = "Newcastle")]
        Newcastle,
        [Display(Name = "Norwich")]
        Norwich,
        [Display(Name = "Southampton")]
        Southampton,
        [Display(Name = "Stoke")]
        Stoke,
        [Display(Name = "Sunderland")]
        Sunderland,
        [Display(Name = "Swansea")]
        Swansea,
        [Display(Name = "Tottenham")]
        Tottenham,
        [Display(Name = "Watford")]
        Watford,
        [Display(Name = "West Brom")]
        WestBrom,
        [Display(Name = "West Ham")]
        WestHam
    }
}
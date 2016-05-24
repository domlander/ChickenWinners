namespace ChickenWinners.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class JoinGameViewModel
    {
        [Required(ErrorMessage = "Please enter a joining code.")]
        [Display(Name = "Joining Code")]
        public int Id { get; set; }
    }
}
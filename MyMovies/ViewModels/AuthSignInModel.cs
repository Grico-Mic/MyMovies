using System.ComponentModel.DataAnnotations;

namespace MyMovies.ViewModels
{
    public class AuthSignInModel
    {
       [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Username { get; set; }
        [Required]
        //[RegularExpression("/(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8}/g",
        // ErrorMessage = "Password must meet requirements")]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
        public int MyProperty { get; set; }
    }
}

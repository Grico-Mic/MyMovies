using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class AuthSignUpModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3,ErrorMessage ="Invalid length.Min 3 chars and max 50 chars.")]
        public string Username { get; set; }

        [Required]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
        //    ErrorMessage = "Passwords must be at least 8 characters and contain at least 3 or 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Invalid length.Min 3 chars and max 50 chars.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}


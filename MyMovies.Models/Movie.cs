

using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Models
{
    public class Movie
    {
        public Movie()
        {
            this.DateCreated = DateTime.Now;
        }
        public int Id { get; set; }

        [Required (ErrorMessage ="This field is required")]
        [StringLength (maximumLength:50, MinimumLength = 5)]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Ganre { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ImageURL { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}

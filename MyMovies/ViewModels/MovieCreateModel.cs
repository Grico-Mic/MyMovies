using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieCreateModel
    {
       

        [Required(ErrorMessage = "This field is required")]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Ganre { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ImageURL { get; set; }
       
    }
}

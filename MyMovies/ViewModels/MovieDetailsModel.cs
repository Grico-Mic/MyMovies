using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Ganre { get; set; }
        public int Duration { get; set; }
        public List<MovieCommentModel> Comments { get; set; }
        public int Views { get; set; }
       
    }
}

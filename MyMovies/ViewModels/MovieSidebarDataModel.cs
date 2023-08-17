using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieSidebarDataModel
    {
        public List<MovieSidebarModel> TopMovies { get; set; } = new List<MovieSidebarModel>();
        public List<MovieSidebarModel> MostRecentMovies { get; set; } = new List<MovieSidebarModel>();
    }
}

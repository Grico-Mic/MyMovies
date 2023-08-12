using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.ViewModels
{
    public class MovieSidebarDataModel
    {
        public List<MovieSidebarModel> TopRecipes { get; set; } = new List<MovieSidebarModel>();
        public List<MovieSidebarModel> MostRecentRecipes { get; set; } = new List<MovieSidebarModel>();
    }
}

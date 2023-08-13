using MyMovies.Mappings;
using MyMovies.Services.Interfaces;
using MyMovies.Servises.Interfaces;
using MyMovies.ViewModels;
using System.Linq;

namespace MyMovies.Services
{
    public class SidebarService : ISidebarService
    {
        private readonly IMoviesServise _servise;

        public SidebarService(IMoviesServise servise)
        {
            _servise = servise;
        }

        public MovieSidebarDataModel GetSidebarData()
        {
            var sidebarDataModel = new MovieSidebarDataModel();

            var mostRecentMovies = _servise.GetMostRecentMovies(5);
            var getTopMovies = _servise.GetTopMovies(5);

            sidebarDataModel.MostRecentRecipes = mostRecentMovies.Select(x => x.ToSidebarModel()).ToList();
            sidebarDataModel.TopRecipes = getTopMovies.Select(x => x.ToSidebarModel()).ToList();

            return sidebarDataModel;
        }
        
    }
}

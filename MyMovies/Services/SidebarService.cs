using Microsoft.Extensions.Options;
using MyMovies.Common.Options;
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
        private readonly SidebarConfig _sidebarConfig;

        public SidebarService(IMoviesServise servise , IOptions<SidebarConfig> sidebarConfig)
        {
            _servise = servise;
            _sidebarConfig = sidebarConfig.Value;
        }

        public MovieSidebarDataModel GetSidebarData()
        {
            var sidebarDataModel = new MovieSidebarDataModel();

            var mostRecentMovies = _servise.GetMostRecentMovies(_sidebarConfig.MostRecentMoviesCount);
            var getTopMovies = _servise.GetTopMovies(_sidebarConfig.TopMoviesCount);

            sidebarDataModel.MostRecentMovies = mostRecentMovies.Select(x => x.ToSidebarModel()).ToList();
            sidebarDataModel.TopMovies = getTopMovies.Select(x => x.ToSidebarModel()).ToList();

            return sidebarDataModel;
        }
        
    }
}

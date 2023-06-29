using MyMovies.Models;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Mappings
{
    public static class DomainModelsExtensions
    {
        public static MovieOverviewModel ToOverviewModel(this Movie movie)
        {
            return new MovieOverviewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                ImageURL = movie.ImageURL,
                Description = movie.Description
            };
        }
        public static MovieManageOverviewModel ToManageOverviewModel(this Movie movie)
        {
            return new MovieManageOverviewModel()
            {
                Id = movie.Id,
                Title = movie.Title
            };
        }
        public static MovieDetailsModel ToDetailsModel(this Movie movie)
        {
            return new MovieDetailsModel()
            {
                Title = movie.Title,
                ImageURL = movie.ImageURL,
                Description = movie.Description,
                Ganre = movie.Ganre,
                Duration = movie.Duration
            };
        }

        public static MovieUpdateModel ToUpdateModel(this Movie viewModel)
        {
            return new MovieUpdateModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                ImageURL = viewModel.ImageURL,
                Description = viewModel.Description,
                Ganre = viewModel.Ganre,
                Duration = viewModel.Duration
            };
        }

        public static UserDetailsModel ToDetailsModel(this User viewModel)
        {
            return new UserDetailsModel()
            {
                Username = viewModel.Username,
                Address = viewModel.Address,
                Email = viewModel.Email
            };
        }
    }
}

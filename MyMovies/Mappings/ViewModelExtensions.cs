using MyMovies.Models;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Mappings
{
    public static class ViewModelExtensions
    {
        public static Movie ToModel(this MovieCreateModel viewModel)
        {
            return new Movie()
            {
                Title = viewModel.Title,
                ImageURL = viewModel.ImageURL,
                Description = viewModel.Description,
                Ganre = viewModel.Ganre,
                Duration = viewModel.Duration
            };
        }

        public static Movie ToUpdateModel(this MovieUpdateModel viewModel)
        {
            return new Movie()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                ImageURL = viewModel.ImageURL,
                Description = viewModel.Description,
                Ganre = viewModel.Ganre,
                Duration = viewModel.Duration
            };
        }

        public static User ToSignUpModel(this AuthSignUpModel viewModel)
        {
            return new User()
            {

                Username = viewModel.Username,
                Password = viewModel.Password,
                Address = viewModel.Address,
                Email = viewModel.Email
            };
        }
    }
}
 
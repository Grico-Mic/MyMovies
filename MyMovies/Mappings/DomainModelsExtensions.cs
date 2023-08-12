using MyMovies.Models;
using MyMovies.ViewModels;
using System.Linq;

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
                Description = movie.Description,
                Views = movie.Views
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
                Id = movie.Id,
                Title = movie.Title,
                ImageURL = movie.ImageURL,
                Description = movie.Description,
                Ganre = movie.Ganre,
                Duration = movie.Duration,
                Comments = movie.Comments.Select(x => x.ToCommentsModel()).ToList(),
                Views = movie.Views
            };
        }
        
        public static MovieCommentModel ToCommentsModel(this Comment comment)
        {
            return new MovieCommentModel()
            {
                Message = comment.Message,
                Username = comment.User.Username,
                DateCreated = comment.DateCreated
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

        public static UsersManageUsersModel ToManageUsersModel(this User viewModel)
        {
            return new UsersManageUsersModel()
            {
                Id = viewModel.Id,
                Username = viewModel.Username,
               IsAdmin = viewModel.IsAdmin
            };
        }

        public static MovieSidebarModel ToSidebarModel(this Movie viewModel)
        {
            return new MovieSidebarModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                DateCreated = viewModel.DateCreated,
                Views = viewModel.Views
            };
        }
    }
}

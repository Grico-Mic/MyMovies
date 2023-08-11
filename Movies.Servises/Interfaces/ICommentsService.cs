using MyMovies.Servises.DtoModels;

namespace MyMovies.Servises.Interfaces
{
    public interface ICommentsService
    {
        StatusModel Add(string comment, int movieId, int userId);
    }
}

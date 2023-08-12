namespace MyMovies.ViewModels
{
    public class MoviesDetailsDataModel
    {
        public MovieDetailsModel MovieDetails { get; set; }
        public MovieSidebarDataModel MovieSidebar { get; set; } = new MovieSidebarDataModel();
    }
}

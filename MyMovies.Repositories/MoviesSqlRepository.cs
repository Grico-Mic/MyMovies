using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesSqlRepository : IMoviesRepository
    {
        //public void Create(Movie movie)
        //{
          
        //    using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyMoviesSql;Trusted_Connection=true;"))
        //    {
        //        cnn.Open();
        //        var query = @"insert into Movies (Title,Ganre,Description,Duration,ImageUrl)
        //                      values(@Title,@Ganre,@Description,@Duration,@ImageUrl)";
        //        var cmd = new SqlCommand(query, cnn);
        //        cmd.Parameters.AddWithValue("@Title", movie.Title);
        //        cmd.Parameters.AddWithValue("@Ganre", movie.Ganre);
        //        cmd.Parameters.AddWithValue("@Description", movie.Description);
        //        cmd.Parameters.AddWithValue("@Duration", movie.Duration);
        //        cmd.Parameters.AddWithValue("@ImageUrl", movie.ImageURL);

        //        cmd.ExecuteNonQuery();
        //    }
        //}

        public void Create(Movie movie)
        {

            using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyMoviesSql;Trusted_Connection=true;"))
            {
                cnn.Open();
               
                var cmd = new SqlCommand("InsertMovie", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Ganre", movie.Ganre);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                cmd.Parameters.AddWithValue("@ImageUrl", movie.ImageURL);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Movie> GetAll()
        {
            var result = new List<Movie>();
            using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyMoviesSql;Trusted_Connection=true;"))
            {
                cnn.Open();
                var query = " Select * from Movies";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movie();

                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Ganre = reader.GetString(2);
                    movie.Description = reader.GetString(3);
                    movie.Duration = reader.GetInt32(4);
                    movie.ImageURL = reader.GetString(5);

                    result.Add(movie);
                 }
                
            }
            return result;
        }
        public Movie GetByTitle(string title)
        {
            Movie result = null;
            using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyMoviesSql;Trusted_Connection=true;"))
            {
                cnn.Open();
                var query = $"select* from Movies where title = @Title ";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", title);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Movie();
                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.Ganre = reader.GetString(2);
                    result.Description = reader.GetString(3);
                    result.Duration = reader.GetInt32(4);
                    result.ImageURL = reader.GetString(5);
                }

            }
            return result;
        }

        public Movie GetById(int id)
        {
           Movie result = null;
            using (var cnn = new SqlConnection("Server=DESCTOP-V9GRIC;Database=MyMoviesSql;Trusted_Connection=true;"))
            {
                cnn.Open();
                var query = $"select* from Movies where id = @id ";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Movie();
                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.Ganre = reader.GetString(2);
                    result.Description = reader.GetString(3);
                    result.Duration = reader.GetInt32(4);
                    result.ImageURL = reader.GetString(5);
                }

            }
            return result;
        }
    }
}

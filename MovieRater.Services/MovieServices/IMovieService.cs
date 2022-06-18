using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IMovieService
    {
        Task<bool> CreateMovieAsync(MovieCreate req);
        Task<IEnumerable<MovieListItem>> GetAllMoviesAsync();
        Task<IEnumerable<MovieDetail>> GetMoviesByGenre(GenreType GenreType);
        Task<IEnumerable<MovieDetail>> GetMoviesByParentalAdv(ParentalAdvisory ParentalAdvisory);
        Task<bool> DeleteMovieReviewByIdAsync(int id);

    }

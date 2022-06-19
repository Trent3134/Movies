using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class MovieService: IMovieService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public MovieService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateMovieAsync(MovieCreate req)
        {
            var newMovie = _mapper.Map<MovieEntity>(req);
            _context.Add(newMovie);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<MovieListItem>> GetAllMoviesAsync()
        {
            var movieListItem = await _context.Movies.ToListAsync();
            var movieList = _mapper.Map<List<MovieListItem>>(movieListItem);

            return movieList;
        }

        public async Task<IEnumerable<MovieDetail>> GetMoviesByGenre(GenreType GenreType)
        {
            var movieG = await _context.Movies.Where(m => m.GenreType == GenreType).ToListAsync();
            //return movieG is null ? null: _mapper.Map<MovieDetail>(movieG);
            if (movieG is null)
            {
                return null;
            }
            return _mapper.Map<List<MovieDetail>>(movieG);
        }

        public async Task<IEnumerable<MovieDetail>> GetMoviesByParentalAdv(ParentalAdvisory ParentalAdvisory)
        {
            var movieParent = await _context.Movies.Where(m => m.ParentalAdvisory == ParentalAdvisory).ToListAsync();
            if (movieParent is null)
            {
                return null;
            }
            return _mapper.Map<List<MovieDetail>>(movieParent);
        }

        public async Task<bool> DeleteMovieReviewByIdAsync(int Id)
        {
            var movieDelete = await _context.Movies.FindAsync(Id);
            if (movieDelete == null)
            {
                return false;
            }
            _context.Movies.Remove(movieDelete);
            return await _context.SaveChangesAsync() == 1;
        }




    }

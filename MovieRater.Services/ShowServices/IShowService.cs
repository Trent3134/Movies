using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IShowService
    {
        Task<ShowEntity> GetShowByTitleAsync(string title);
        Task<ShowEntity> GetShowByCastAsync(string cast);
        Task<ShowEntity> GetShowByGenreTypeAsync(GenreType GenreType);
        Task<IEnumerable<ShowListItem>> GetAllShowsAsync();
        Task<bool> CreateShowAsync(ShowCreate model);
        Task<ShowDetail> GetShowByIdAsync(int showId);
        Task<bool> UpdateShowAsync(ShowUpdate request);
        Task<bool> DeleteShowAsync(int showId);
    }

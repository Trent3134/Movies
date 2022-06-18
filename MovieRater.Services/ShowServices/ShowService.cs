using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class ShowService : IShowService
    {
        private readonly IShowService _sService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ShowService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> ShowAsync(ShowCreate model)
        {

            var entity = new ShowEntity
            {
                Title = model.Title,
                Cast = model.Cast,
                Review = model.Review,
                GenreType = model.GenreType
            };

            _context.Shows.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges ==1;
        }

        public async Task<ShowEntity> GetShowByTitleAsync(string title)
        {
            var show = await _context.Shows.Where(show => show.Title == title).ToListAsync();
            if (show is null)
            {
                return null;
            }
            return _mapper.Map<ShowEntity>(show);
            
        }

        public async Task<ShowEntity> GetShowByCastAsync(string cast)
        {
            var show = await _context.Shows.Where(show => show.Cast == cast).ToListAsync();
            if (show is null)
            {
                return null;
            }
            return _mapper.Map<ShowEntity>(show);
        }

        public async Task<ShowEntity> GetShowByGenreTypeAsync(GenreType GenreType)
        {
            var show = await _context.Shows.Where(show => show.GenreType == GenreType).ToListAsync();
            if (show is null)
            {
                return null;
            }
            return _mapper.Map<ShowEntity>(show);
        }

        public async Task<IEnumerable<ShowListItem>> GetAllShowsAsync()
        {
            var shows = await _context.Shows
            .Where(showEntity => showEntity.Id == showEntity.Id).ToListAsync()
            .Select(showEntity => new ShowListItem
            {
                Id = shows.Id,
                Title = shows.Title,
                GenreType = shows.GenreType
            }) .ToListAsync();
            return shows;
        }

        public async Task<ShowDetail> GetShowByIdAsync(int Id)
        {
            var showEntity = await _context.Shows
                .FirstOrDefault(e => 
                e.Id == Id && e.ShowId == Id);
                return showEntity is null ? null: _mapper.Map<ShowDetail>(showEntity);
        }

        public async Task<bool> UpdateShowAsync (ShowsUpdate request)
        {
            var showEntity = await _context.Shows.FindAsync(request.Id);
            if (showEntity?)
        }
    }

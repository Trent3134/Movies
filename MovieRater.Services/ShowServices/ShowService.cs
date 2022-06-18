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
        public async Task<bool> CreateShowAsync(ShowCreate model)
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
            var shows = await _context.Shows.ToListAsync();
            var showList = _mapper.Map<List<ShowListItem>>(shows);
            return showList;
        }

        public async Task<ShowDetail> GetShowByIdAsync(int Id)
        {
            var showEntity = await _context.Shows
                .FirstOrDefaultAsync(e => 
                e.Id == Id);
                return showEntity is null ? null: _mapper.Map<ShowDetail>(showEntity);
        }

        public async Task<bool> UpdateShowAsync (ShowUpdate request)
        {
            var showEntity = await _context.Shows
            .FirstOrDefaultAsync(e =>
            e.Id == request.Id);
            if (showEntity == null)
            {
                return false;
            }
            var newEntity = _mapper.Map(request, showEntity);
            _context.Shows.Update(newEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteShowAsync(int showId)
        {
            var showEntity = await _context.Shows.FindAsync(showId);
            if (showEntity == null)
            {
                return false;
            }
            _context.Shows.Remove(showEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }

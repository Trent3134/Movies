using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class RatingService : IRatingService
    {
    private readonly ApplicationDbContext _dbContext;
        public RatingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool>CreateRatingAsync(RatingCreate request)
        {
            var ratingEntity= new RatingEntity
            {
                Stars = request.Stars,
                Review = request.Review,
                MovieEntityId = request.MovieEntityId,
                ShowEntityId = request.ShowEntityId

            };

            _dbContext.Ratings.Add(ratingEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;

        }

        public async Task<IEnumerable<RatingListItem>> GetAllRatingsAsync()
        {
            var ratings = await _dbContext.Ratings
                .Select(entity=> new RatingListItem
                {
                    Id = entity.Id,
                    Stars = entity.Stars,
                    Review = entity.Review

                })
                .ToListAsync();
                return ratings;
        }
        public async Task<bool> UpdateRatingAsync(RatingUpdate request)
        {
            var ratingEntity = await _dbContext.Ratings.FindAsync(request.Id);

            ratingEntity.Review = request.Review;
            ratingEntity.Stars = request.Stars;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;

        }

        public async Task<bool> DeleteRatingByIdAsync(int ratingId)
        {
            var ratingEntity = await _dbContext.Ratings.FindAsync(ratingId);

            _dbContext.Ratings.Remove(ratingEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }

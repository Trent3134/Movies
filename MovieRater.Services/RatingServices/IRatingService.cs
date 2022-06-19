using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IRatingService
    {

        Task<bool>CreateRatingAsync(RatingCreate request);
        Task<IEnumerable<RatingListItem>> GetAllRatingsAsync();
       
    }

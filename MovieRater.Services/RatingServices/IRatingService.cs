using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public interface IRatingService
    {


        Task<IEnumerable<RatingListItem>> GetAllRatingsAsync();
       
    }

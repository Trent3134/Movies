using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController (IRatingService ratingService)
        {
            ratingService = _ratingService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllRatingsAsync();
            return Ok(ratings);
        }
    }

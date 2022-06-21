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
        
        [HttpPost]
        public async Task<IActionResult> CreateRating([FromBody] RatingCreate request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(await _ratingService.CreateRatingAsync(request)) return Ok(("Rating "));
            return BadRequest("Rating could not be created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllRatingsAsync();
            return Ok(ratings);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateRatingByID([FromBody] RatingUpdate request)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            return await _ratingService.UpdateRatingAsync(request)
            ? Ok("Rating Successfeully Updated")
            : BadRequest("Rating could not be updated");
        }

        [HttpDelete("{ratingId:int}")]
        public async Task<IActionResult> DeleteRating([FromRoute] int ratingId)
        {
            return await _ratingService.DeleteRatingByIdAsync(ratingId)
                ? Ok(($"Rating {ratingId} was deleted successfully"))
                : BadRequest($"Rating {ratingId} could not be deleted");
        }

    }

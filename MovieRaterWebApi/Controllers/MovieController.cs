using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
        {
        _movieService = movieService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovieReview([FromBody] MovieCreate req)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        if (await _movieService.CreateMovieAsync(req))
        {
            return Ok("Movie review was created!");
        }
        return BadRequest("Movie review could not be created.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMovieReviewes()
    {
        var movies1 = await _movieService.GetAllMoviesAsync();
        return Ok(movies1);
    }

    [HttpGet("ReviewByGenre/{GenreType:int}")]
    public async Task<IActionResult> GetMovieReviewByGenre([FromRoute] GenreType GenreType)
    {
        var movieGenre = await _movieService.GetMoviesByGenre(GenreType);
        return movieGenre is not null ? Ok(movieGenre) : NotFound();
    }

    [HttpGet("ReviewByParentalAdvisory/{ParentalAdivsory:int}")]
    public async Task<IActionResult> GetmovieReviewByParentalAdvisory([FromRoute] ParentalAdvisory ParentalAdvisory)
    {
        var movieParent = await _movieService.GetMoviesByParentalAdv(ParentalAdvisory);
        return movieParent is not null ? Ok(movieParent) : NotFound();
    }

    [HttpDelete("{Id:int}")]
    public async Task<IActionResult> DeleteMovieReview([FromRoute] int Id)
    {
        return await _movieService.DeleteMovieReviewByIdAsync(Id) ? Ok("Movie review was deleted successfully") : BadRequest("Movie review was not deleted.");
        
    }

    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


        [Route("api/[ShowController]")]
        [ApiController]
        public class ShowController : ControllerBase
        {
            private readonly IShowService _sService;
            public ShowController(IShowService service)
            {
                _sService = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllShows()
            {
                var shows = await _sService.GetAllShowsAsync();
                return Ok(shows);
            }

            [HttpPost]
            public async Task<IActionResult> CreateShow([FromBody] ShowCreate request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                    if (await _sService.CreateShowAsync(request))
                    return Ok("Show was Created");

                    return BadRequest("Show could not be created");
            }

            [HttpGet("{showId: int")]
            public async Task<IActionResult> GetShowById([FromRoute] int showId)
            {
                var detail = await _sService.GetShowByIdAsync(showId);
                return detail is not null
                    ? Ok(detail)
                    : NotFound();
            }

            [HttpPut]
            public async Task<IActionResult> UpdateShowById([FromBody] ShowUpdate request)
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return await _sService.UpdateShowAsync(request)? Ok("Show was updated"): BadRequest("Show was not updated");
            }

            [HttpDelete("{showId:int}")]
            public async Task<IActionResult> DeleteShow([FromRoute] int showId)
            {
                return await _sService.DeleteShowAsync(showId)
                    ? Ok($"Show {showId} was deleted!")
                    : BadRequest($"Show {showId} could not be deleted!");
            }
        }
    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using V4_API_Movies_M2M_RepoPattern_EF_CodeFirst_Identity_JWTToken.Data;
using V4_API_Movies_M2M_RepoPattern_EF_CodeFirst_Identity_JWTToken.DTO;
using V4_API_Movies_M2M_RepoPattern_EF_CodeFirst_Identity_JWTToken.Models;

namespace V4_API_Movies_M2M_RepoPattern_EF_CodeFirst_Identity_JWTToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IRepository repository;
        public MoviesController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Movies
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = repository.GetMovies();
            if (!movies.Any())
            {
                return NoContent();
            }
            return Ok(movies);
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult Get(int id)
        {
            var movie = repository.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult Post([FromBody] MovieDTO movie)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.AddMovie(movie);
                if (result)
                {
                    return Created("AddMovie", movie);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

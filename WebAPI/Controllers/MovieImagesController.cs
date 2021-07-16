using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieImagesController : ControllerBase
    {
        private readonly IMovieImageService _movieImageService;

        public MovieImagesController(IMovieImageService movieImageService)
        {
            _movieImageService = movieImageService;
        }

        [HttpPost]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] MovieImage movieImage)
        {
            var result = _movieImageService.Add(file, movieImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] MovieImage movieImage)
        {
            var result = _movieImageService.Update(file, movieImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(MovieImage movieImage)
        {
            var result = _movieImageService.Delete(movieImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _movieImageService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _movieImageService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

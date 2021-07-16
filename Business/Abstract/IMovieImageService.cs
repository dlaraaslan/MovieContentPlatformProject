using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMovieImageService
    {
        IResult Add(IFormFile file, MovieImage movieImage);
        IResult Update(IFormFile file, MovieImage movieImage);
        IResult Delete(MovieImage movieImage);
        IDataResult<List<MovieImage>> GetAll();
       
        IDataResult<MovieImage> GetById(int id);
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IResult Add(Movie movie);
        IResult Update(Movie movie);
        IResult Delete(Movie movie);
        IDataResult<List<Movie>> GetAll();
        IDataResult<Movie> GetById(int Id);
        IDataResult<List<MovieDetailDto>> GetByDetailsMovieId(int Id);
    }
}

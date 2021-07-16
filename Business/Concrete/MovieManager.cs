using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private IMovieDal _movieDal;
        private IMovieImageDal _movieImageDal;

        public MovieManager(IMovieDal movieDal, IMovieImageDal movieImageDal) {
            _movieDal = movieDal;
            _movieImageDal = movieImageDal;
        }



        public IResult Add(Movie movie)
        {
            _movieDal.Add(movie);
            var query = _movieDal.Get(p => p.Id == movie.Id);
            var image = new MovieImage 
            {
                MovieId = query.Id,
                ImageDate = DateTime.Now,
                ImagePath = "/Images/default.jpg"
            };
            _movieImageDal.Add(image);
            return new SuccessResult(Messages.MovieAdded);
        }

        public IResult Delete(Movie movie)
        {
            _movieDal.Delete(movie);
            return new SuccessResult(Messages.MovieDeleted);
        }

        public IDataResult<List<Movie>> GetAll()
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(), Messages.MovieListed);
        }

        public IDataResult<List<MovieDetailDto>> GetByDetailsMovieId(int Id)
        {
            return new SuccessDataResult<List<MovieDetailDto>>(_movieDal.GetByDetailsMovieId(Id));
        }

        public IDataResult<Movie> GetById(int Id)
        {
            return new SuccessDataResult<Movie>(_movieDal.Get(m => m.Id == Id));
        }

        public IResult Update(Movie movie)
        {
            _movieDal.Update(movie);
            return new SuccessResult(Messages.MovieUpdated);
        }
    }
}

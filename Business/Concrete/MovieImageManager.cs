using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class MovieImageManager : IMovieImageService
    {
        private IMovieImageDal _movieImageDal;
        private IMovieService _movieService;

        public MovieImageManager(IMovieImageDal movieImageDal, IMovieService movieService) {
            _movieImageDal = movieImageDal;
            _movieService = movieService;
        }


        public IResult Add(IFormFile file, MovieImage movieImage)
        {
            var result = BusinessRules.Run(CheckMovieImagesCount(movieImage.MovieId));
            if (result != null) return result;
            var query = this.GetById(movieImage.MovieId).Data;
            if (query.ImagePath.Contains("default"))
            {
                movieImage.ImagePath = FileHelper.SaveImageFile("Images", file);
                movieImage.ImageDate = DateTime.Now;
                movieImage.ImageId = query.ImageId;
                movieImage.MovieId = movieImage.MovieId;
                _movieImageDal.Update(movieImage);
            }
            else
            {
                movieImage.ImagePath = FileHelper.SaveImageFile("Images", file);
                movieImage.ImageDate = DateTime.Now;
                _movieImageDal.Add(movieImage);
            }

            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(MovieImage movieImage)
        {
            var entity = _movieImageDal.Get(mi => mi.ImageId == movieImage.ImageId);
            if (entity == null) return new ErrorResult(Messages.ImageNotFound);
            FileHelper.DeleteImageFile(entity.ImagePath);
            _movieImageDal.Delete(movieImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<MovieImage> GetById(int id)
        {
            var Image = _movieImageDal.Get(mi => mi.ImageId == id);
            if (Image == null) return new ErrorDataResult<MovieImage>(Messages.ImageNotFound);
            return new SuccessDataResult<MovieImage>(Image);
        }

        public IDataResult<List<MovieImage>> GetAll()
        {
            return new SuccessDataResult<List<MovieImage>>(_movieImageDal.GetAll());
        }

        public IResult Update(IFormFile file, MovieImage movieImage)
        {
            var entity = _movieImageDal.Get(mi => mi.ImageId == movieImage.ImageId);
            if (entity == null) return new ErrorResult(Messages.ImageNotFound);
            FileHelper.DeleteImageFile(entity.ImagePath);
            entity.ImagePath = FileHelper.SaveImageFile("Images", file);
            entity.ImageDate = DateTime.Now;
            _movieImageDal.Update(entity);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckMovieImagesCount(int movieId)
        {
            var result = _movieImageDal.GetAll(mi => mi.MovieId == movieId).Count < 5;
            if (!result) return new ErrorResult(Messages.ImageCountExceeded);
            return new SuccessResult();
        }
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Repository
{
    public class EfMovieDal : EfEntityRepositoryBase<Movie, MoviePlatformContext>, IMovieDal
    {
        //GetByMovieId

        public List<MovieDetailDto> GetByDetailsMovieId(int movieId)
        {
            using (MoviePlatformContext context = new MoviePlatformContext())
            {

                var result = from m in context.Movies
                             join im in context.MovieImages on m.Id equals im.MovieId
                             where m.Id == movieId
                             select new MovieDetailDto
                             {
                                 Id = m.Id,
                                 Name = m.Name,
                                 Type = m.Type,
                                 Year = m.Year,
                                 IMDB = m.IMDB,
                                 Review = m.Review,

                                 Date = im.ImageDate,
                                 ImagePath = im.ImagePath,
                                 ImageId = im.ImageId
                             };
                return result.ToList();
            }
        }

    }
}

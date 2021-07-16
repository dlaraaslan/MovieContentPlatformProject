using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MovieImage : IEntity
    {
        public int ImageId { get; set; }
        public int MovieId { get; set; }
        public string ImagePath { get; set; }
        public DateTime ImageDate { get; set; }


    }
}

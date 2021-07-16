using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MovieDetailDto :IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public int IMDB { get; set; }
        public string Review { get; set; }

        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

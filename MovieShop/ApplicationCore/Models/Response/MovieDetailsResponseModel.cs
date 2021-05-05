using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Response
{
    public class MovieDetailsResponseModel
    {
        public Movie Movie { get; set; }
        public List<CastModel> Casts { get; set; }
        public List<Genre> Genres { get; set; }
    }

    public class CastModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public string Character { get; set; }
    }
}

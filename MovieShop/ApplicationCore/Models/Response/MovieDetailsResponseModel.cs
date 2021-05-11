using System;
using System.Collections.Generic;

namespace ApplicationCore.Models.Response
{
    public class MovieDetailsResponseModel
    {
        public MovieModel Movie { get; set; }
        public List<CastModel> Casts { get; set; }
        public List<GenreModel> Genres { get; set; }
    }

    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }

        //decimal? allows to have nullable value
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CReatedBy { get; set; }

        //[NotMapped] //not create column for this property
        public decimal? Rating { get; set; }
    }

    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CastModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public string Character { get; set; }
    }
}

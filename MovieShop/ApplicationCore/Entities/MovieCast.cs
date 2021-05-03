using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("MovieCast")]
    public class MovieCast
    {
        [Key]
        [Column(Order = 1)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CastId { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Character { get; set; }

        public Cast Cast { get; set; }
        public Movie Movie { get; set; }
    }
}

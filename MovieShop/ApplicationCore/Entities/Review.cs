using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [Column(Order = 1)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }
        public decimal? Rating { get; set; }
        public string ReviewText { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}

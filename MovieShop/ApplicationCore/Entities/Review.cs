using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Review
    {
        [Key]
        [Column(Order = 1)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }
        public Decimal Rating { get; set; }
        public string ReviewText { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class MovieCrew
    {
        [Key]
        [Column(Order = 1)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CrewId { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Department { get; set; }

        [Key]
        [Column(Order = 4)]
        public string Job { get; set; }
    }
}

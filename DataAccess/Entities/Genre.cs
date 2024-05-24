#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Genre : RecordBase
    {
        [Required]
        [StringLength(50)]
        public string GenreName { get; set; }
        public List<Movie> Movies { get; set; }

    }
}

#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Studio : RecordBase
    {
        [Required]
        [StringLength(60)]
        public string StudioName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}

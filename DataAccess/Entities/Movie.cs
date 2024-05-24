#nullable disable
using DataAccess.Enums;
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Movie : RecordBase
    {
        [Required]
        [StringLength(100)]
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int GenreId { get; set; } //foreign key
        public int StudioId { get; set; } //foreign key
        public List<MovieActor> MovieActors { get; set; }
		public Genre Genre { get; set; }
		public Studio Studio { get; set; }
		public Review Review { get; set; }



	}
}

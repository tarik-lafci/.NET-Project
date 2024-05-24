#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
	public class MovieModel : RecordBase
	{
		#region Entity Properties 
		[Required]
		[StringLength(100)]
		public string MovieName { get; set; }
		public decimal Price { get; set; }
		public bool IsReleased { get; set; }
		public DateTime? ReleaseDate { get; set; }
		public int GenreId { get; set; } //foreign key
		public int StudioId { get; set; } //foreign key
		#endregion
	}
}

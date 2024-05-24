#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Actor : RecordBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsActive { get; set; }

        public decimal Score { get; set; } //between 0 and 5
        public List<MovieActor> MovieActors { get; set; }
    }
}

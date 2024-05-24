#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class ActorModel : RecordBase
    {
        #region Entity Properties
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "{0} must be minimum {2} and maximum {1} characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "{0} must be minimum {2} and maximum {1} characters!")]
        public string Surname { get; set; }
        [DisplayName("Birth Date")]

        public DateTime? BirthDate { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Range(0, 5, ErrorMessage = "{0} must be between {1} and {2}!")]
        public decimal? Score { get; set; } //between 0 and 5
		#endregion

		#region Extra Properties
		[DisplayName("Movies")]
		public List<int> MovieIdsInput { get; set; }
        [DisplayName("Birth Date")]
        public string BirthDateOutput { get; set; }

        [DisplayName("Active")]
        public string IsActiveOutput { get; set; }

        [DisplayName("Score")]
        public string ScoreOutput { get; set; }

        [DisplayName("Full Name")]
        public string FullNameOutput { get; set; }

		[DisplayName("Movies")]
		public string MovieNamesOutput { get; set; }

        
        #endregion
    }
}

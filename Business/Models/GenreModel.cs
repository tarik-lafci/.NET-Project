#nullable disable
using DataAccess.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class GenreModel : RecordBase
    {
        #region Entity Properties
        [Required(ErrorMessage ="{0} is required!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage ="{0} must be minimum {2} and maximum {1} characters!")]
        [DisplayName ("Genre Name")] //{0} uses DisplayName if it exists, if it does not it uses Below
        public string GenreName { get; set; }
        #endregion

        #region Extra Properties
        [DisplayName("Movie Count")]
        public int MovieCountOutput { get; set; }

        [DisplayName("Movie Names")]
        public string MovieNamesOutput { get; set;}
        #endregion
    } 
}

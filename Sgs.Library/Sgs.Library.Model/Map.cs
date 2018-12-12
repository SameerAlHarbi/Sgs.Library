using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Library.Model
{
    public class Map : Book
    {

        [Required(ErrorMessage = "{0} is Required !")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Unvalid {0} !")]
        [DisplayName("Arabic Name")]
        public string ArabicName { get; set; }

        public int MapTypeId { get; set; }
            
        public MapType MapType { get; set; }

        [Required(ErrorMessage = "{0} is Required !")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Unvalid {0} !")]
        [DisplayName("Map Size")]
        public string MapSize { get; set; }

        [Required(ErrorMessage = "Abstract is Required !")]
        public string Abstract { get; set; }

        public bool HasAttachment { get; set; }

        [StringLength(30, ErrorMessage = "Unvalid Region !")]
        public string Region { get; set; }

        public string Status { get; set; }

    }
}

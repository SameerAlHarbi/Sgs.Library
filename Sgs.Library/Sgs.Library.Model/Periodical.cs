using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Library.Model
{
    public class Periodical : Book
    {
        
        [Required(ErrorMessage = "{0} is Required !")]
        [DisplayName("Periodicals Date")]
        public DateTime PeriodicalDate { get; set; }

    }
}

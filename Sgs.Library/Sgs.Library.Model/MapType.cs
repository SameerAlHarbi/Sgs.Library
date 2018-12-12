using Sameer.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sgs.Library.Model
{
    public class MapType:ISameerObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required ..!")]
        [Unique(ErrorMessage = "Name dupilcate ..!")]
        [StringLength(50, MinimumLength =1,ErrorMessage ="Unvalid Name !")]
        public string Name { get; set; }

        public List<Map> MapsList { get; set; }

        public MapType()
        {
            this.MapsList = new List<Map>();
        }
    }
}

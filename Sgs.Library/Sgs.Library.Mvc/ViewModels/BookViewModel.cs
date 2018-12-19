using Microsoft.AspNetCore.Mvc;
using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Library.Mvc.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is Required !")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Unvalid {0} !")]
        [DisplayName("Name")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Author is Required !")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Unvalid Author !")]
        public virtual string Author { get; set; }

        [Required(ErrorMessage = "Code is Required !")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Unvalid Code !")]
        [Remote(action: "VerifyCode", controller: "Books", AdditionalFields = nameof(Id))]
        public virtual string Code { get; set; }

        //..... Contenue
    }
}

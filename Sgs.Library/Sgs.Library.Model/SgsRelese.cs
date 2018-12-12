using Sameer.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgs.Library.Model
{
    public abstract class SgsRelese : ISameerObject
    {
        [Key]
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
        [Unique(ErrorMessage = "Code dupilcate !")]
        public virtual string Code { get; set; }

        [Required(ErrorMessage = "Release Yaer is Required !")]
        [Range(1900, 2060, ErrorMessage = "Unvalid Release Yaer !")]
        public virtual int ReleaseYaer { get; set; }

        [Required(ErrorMessage = "Price is Required !")]
        [Range(0, 10000000, ErrorMessage = "Unvalid Price !")]
        [Column(TypeName = "Money")]
        public virtual decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is Required !")]
        [Range(0, 10000, ErrorMessage = "Unvalid Quantity !")]
        public virtual int Quantity { get; set; }

        [Required(ErrorMessage = "Row Number is Required is Required !")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Unvalid Row Number !")]
        public virtual string RowNumber { get; set; }

        [Required(ErrorMessage = "Shelf Number is Required !")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Unvalid Shelf Number !")]
        public virtual string ShelfNumber { get; set; }

        [Required(ErrorMessage = "Column Number is Required !")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Unvalid Column Number  !")]
        public virtual string ColumnNumber { get; set; }

    }
}

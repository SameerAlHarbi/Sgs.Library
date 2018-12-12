using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sgs.Library.Model
{
    public class Borrow : ISameerObject,IValidatableObject
    {
        public int Id { get; set; }

        public int? BookId { get; set; }

        public Book Book { get; set; }

        public int? MapId { get; set; }

        public Map Map { get; set; }

        public int? ReportId { get; set; }   

        public Report Report { get; set; }

        public int? PeriodicalId { get; set; }

        public Periodical Periodical { get; set; }

        [Required(ErrorMessage = "Employee Id is Required !")]
        [Range(1,10000, ErrorMessage = "Unvalid Employee Id !")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Borrow Date is Required !")]
        public DateTime BorrowDate { get; set; }

        public bool IsReturn { get; set; }

        public DateTime? ReturnDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var resulte = new List<ValidationResult>();

            if(!BookId.HasValue && !ReportId.HasValue && !MapId.HasValue && !PeriodicalId.HasValue)
            {
                resulte.Add(new ValidationResult("Unvalid Borrow ..!", new string[] { "EmployeeId" , "BorrowDate" }));
            }

            return resulte;
        }
    }
}

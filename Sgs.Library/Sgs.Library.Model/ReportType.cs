using Sameer.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sgs.Library.Model
{
    public class ReportType : ISameerObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required ..!")]
        [Unique(ErrorMessage = "Name dupilcate ..!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Unvalid Name !")]
        public string Name { get; set; }

        public List<Report> ReportsList { get; set; }

        public ReportType()
        {
            this.ReportsList = new List<Report>();
        }

    }
}

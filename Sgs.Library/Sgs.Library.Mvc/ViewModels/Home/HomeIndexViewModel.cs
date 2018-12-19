using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Library.Mvc.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public int BooksCount { get; set; }
        public int ReportsCount { get; set; }
        public int MapsCount { get; set; }
        public int PeriodicalsCount { get; set; }
    }
}

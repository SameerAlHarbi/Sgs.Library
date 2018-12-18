using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sgs.Library.BusinessLogic;
using Sgs.Library.Mvc.Services;
using Sgs.Library.Mvc.ViewModels.Home;
using System.Linq;

namespace Sgs.Library.Mvc.Controllers
{
    public class HomeController :BaseController
    {
        private readonly BooksManager _booksManager;
        public HomeController(BooksManager booksManager,IMapper mapper, ILogger<HomeController> logger)
            : base(mapper, logger)
        {
            _booksManager = booksManager;
        }

        public IActionResult Index()
        {
            var vm = new HomeIndexViewModel()
            {
                //BooksCount = _booksManager.GetAll().Count(),
                BooksCount=5000,
                MapsCount=3500,
                ReportsCount=6300,
                PeriodicalsCount=580
            };
            return View(vm);
        }
    }
}

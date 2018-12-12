using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sgs.Library.Mvc.Services;

namespace Sgs.Library.Mvc.Controllers
{
    public class HomeController :BaseController
    {
        public HomeController(IAppInfo appInfoManager,IMapper mapper, ILogger<HomeController> logger)
            : base(mapper, logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

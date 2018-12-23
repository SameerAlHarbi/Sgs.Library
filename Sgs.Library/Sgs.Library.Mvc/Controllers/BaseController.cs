using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sgs.Library.Mvc.Controllers
{
    public class BaseController : Controller
    {
        protected IMapper _mapper;
        protected ILogger _logger;

        public BaseController(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}

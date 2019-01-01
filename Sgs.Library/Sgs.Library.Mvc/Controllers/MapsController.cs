using AutoMapper;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sgs.Library.BusinessLogic;
using Sgs.Library.Model;
using Sgs.Library.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Library.Mvc.Controllers
{
    public class MapsController : GeneralMvcController<Map, MapViewModel>
    {
        public MapsController(MapsManager dataManager, IMapper mapper, ILogger logger) : base("Map", dataManager, mapper, logger)
        {
        }
    }
}

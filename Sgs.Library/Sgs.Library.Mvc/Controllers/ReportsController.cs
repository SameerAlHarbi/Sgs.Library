using AutoMapper;
using Microsoft.Extensions.Logging;
using Sameer.Shared.Data;
using Sgs.Library.BusinessLogic;
using Sgs.Library.Model;
using Sgs.Library.Mvc.ViewModels;

namespace Sgs.Library.Mvc.Controllers
{
    public class ReportsController : GeneralMvcController<Report, ReportViewModel>
    {
        public ReportsController(GeneralManager<Report> dataManager, IMapper mapper, ILogger<ReportsController> logger) 
            : base("Report", dataManager, mapper, logger)
        {
        }
    }
}

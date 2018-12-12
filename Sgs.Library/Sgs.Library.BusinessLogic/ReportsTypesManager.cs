using Sameer.Shared.Data;
using Sgs.Library.Model;

namespace Sgs.Library.BusinessLogic
{
    public class ReportsTypesManager : GeneralManager<ReportType>
    {
        public ReportsTypesManager(IRepository repo) : base(repo)
        {
        }
    }
}

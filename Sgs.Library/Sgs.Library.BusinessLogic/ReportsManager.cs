using Sameer.Shared.Data;
using Sgs.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sgs.Library.BusinessLogic
{
    public class ReportsManager : GeneralManager<Report>
    {
        public ReportsManager(IRepository repo) : base(repo)
        {
        }
    }
}

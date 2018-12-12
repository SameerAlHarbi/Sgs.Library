using Sameer.Shared.Data;
using Sgs.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sgs.Library.BusinessLogic
{
    public class PeriodicalsManager : GeneralManager<Periodical>
    {
        public PeriodicalsManager(IRepository repo) : base(repo)
        {
        }
    }
}

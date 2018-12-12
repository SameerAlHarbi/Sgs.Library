using Sameer.Shared.Data;
using Sgs.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sgs.Library.BusinessLogic
{
    public class MapsManager : GeneralManager<Map>
    {
        public MapsManager(IRepository repo) : base(repo)
        {
        }
    }
}

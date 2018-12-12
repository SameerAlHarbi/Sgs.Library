using Sameer.Shared.Data;
using Sgs.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sgs.Library.BusinessLogic
{
    public class BorrowingsManager : GeneralManager<Borrow>
    {
        public BorrowingsManager(IRepository repo) : base(repo)
        {
        }
    }
}

using Sameer.Shared.Data;
using Sgs.Library.Model;

namespace Sgs.Library.BusinessLogic
{
    public class BooksManager : GeneralManager<Book>
    {
        public BooksManager(IRepository repo) : base(repo)
        {
        }
    }
}

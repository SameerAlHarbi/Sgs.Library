using Microsoft.EntityFrameworkCore;
using Sameer.Shared.Data;
using Sgs.Library.Model;
using System;
using System.Threading.Tasks;

namespace Sgs.Library.BusinessLogic
{
    public class BooksManager : GeneralManager<Book>
    {
        public BooksManager(IRepository repo) : base(repo)
        {
        }

        public async Task<Book> GetBookByCode(string bookCode)
        {
            try
            {
                var result = await this.GetAll(b => b.Code.Trim().ToUpper() == bookCode.Trim().ToUpper())
                    .FirstOrDefaultAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

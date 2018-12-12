using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sgs.Library.Model;
using Sgs.Library.BusinessLogic;

namespace Sgs.Library.Mvc.Controllers
{
    public class BooksController : BaseController
    {
        private readonly BooksManager _booksManager;
        public BooksController(BooksManager booksManager, IMapper mapper, ILogger<BooksController> logger) : base(mapper, logger)
        {
            _booksManager = booksManager;
        }

        public async Task<IActionResult> Index()
        {
            var booksList = await _booksManager.GetAllAsNoTrackingListAsync();

            return View(booksList);
        }
    }
}

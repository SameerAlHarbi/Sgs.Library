using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sgs.Library.BusinessLogic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Sgs.Library.Mvc.ViewModels;
using Sgs.Library.Model;

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
            //var booksList = await _booksManager.GetAllAsNoTrackingListAsync();
            //return View(booksList);
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var book = await _booksManager
                    .GetAll(b => b.Code.Trim().ToUpper() == model.Code.Trim().ToUpper())
                    .FirstOrDefaultAsync();

                    if (book == null)
                    {
                        var newBook =  _mapper.Map<Book>(model);

                        var result = await _booksManager.InsertNewAsync(newBook);

                        if (result.Status == Sameer.Shared.Data.RepositoryActionStatus.Created)
                        {
                            _logger.LogInformation("Book created.");
                            return RedirectToAction(nameof(BooksController.Index));
                        }
                        else
                        {
                                ModelState.AddModelError(string.Empty, "Error"); 
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Code", "Book code is alreadey exist !!");
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error happend");
                }
            }
            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> VerifyCode(string code, int id = 0)
        {
            try
            {
                var book = await _booksManager
                    .GetAll(b => b.Code.Trim().ToUpper() == code.Trim().ToUpper())
                    .FirstOrDefaultAsync();
                if (book != null && book.Id != id)
                {
                    return Json($"Sorry book code - {code} is already registered !");
                }
                return Json(true);
            }
            catch (Exception)
            {
                return Json("validation error ...!!");
            }
        }
    }
}

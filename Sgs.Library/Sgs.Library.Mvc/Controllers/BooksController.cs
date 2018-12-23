using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sameer.Shared.Data;
using Sgs.Library.BusinessLogic;
using Sgs.Library.Model;
using Sgs.Library.Mvc.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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
                    _logger.LogInformation("Creating a new book !");

                    var newData = _mapper.Map<Book>(model);

                    using (_booksManager)
                    {

                        var saveResult = await _booksManager.InsertNewAsync(newData);

                        if (saveResult.Status == RepositoryActionStatus.Created)
                        {
                            _logger.LogInformation("Book created successfully.");
                            return RedirectToAction(nameof(BooksController.Index));
                        }
                        else
                        {
                            _logger.LogWarning("Could not save new book to the database !");
                            ModelState.AddModelError(string.Empty, "Save error please try again later !");
                        } 

                    }

                }
                catch (ValidationException ex)
                {
                    _logger.LogWarning($"validation exception while save new book : {ex.ValidationResult.ErrorMessage}");
                    ModelState.AddModelError("", ex.ValidationResult.ErrorMessage);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Throw exception while save new book : {ex}");
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

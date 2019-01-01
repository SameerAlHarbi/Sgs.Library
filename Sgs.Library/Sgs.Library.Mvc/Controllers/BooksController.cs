using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sameer.Shared.Data;
using Sgs.Library.BusinessLogic;
using Sgs.Library.Model;
using Sgs.Library.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Sgs.Library.Mvc.Controllers
{
    public class BooksController : BaseController
    {
        private readonly GeneralManager<Book> _booksManager;
        public BooksController(GeneralManager<Book> booksManager, IMapper mapper, ILogger<BooksController> logger) : base(mapper, logger)
        {
            _booksManager = booksManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("IndexAsync")]
        public async Task<IActionResult> IndexAsync()
        {
            var booksList = await _booksManager.GetAllAsNoTrackingListAsync();
            return View(_mapper.Map<List<BookViewModel>>(booksList));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var currentBook = await _booksManager.GetByIdAsync(id);

                if (currentBook == null)
                {
                    return NotFound();
                }

                return View(_mapper.Map<BookViewModel>(currentBook));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new BookViewModel());
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
                            return RedirectToAction(nameof(Details),new { id = newData.Id});
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var currentBook = await _booksManager.GetByIdAsync(id);

                if (currentBook == null)
                {
                    return NotFound();
                }

                return View(_mapper.Map<BookViewModel>(currentBook));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation($"Updating book with id of {id}");

                    using (_booksManager)
                    {
                        var currentData = await _booksManager.GetByIdAsync(id);
                        if (currentData == null)
                        {
                            _logger.LogWarning($"Can't find book with id of {id}");
                            return NotFound();
                        }

                        _mapper.Map(model, currentData);

                        var updateResult = await _booksManager.UpdateItemAsync(currentData);
                        if (updateResult.Status == RepositoryActionStatus.Updated)
                        {
                            _logger.LogInformation("Book updated successfully.");
                            return RedirectToAction(nameof(Details),new { id });
                        }
                        else
                        {
                            _logger.LogWarning("Could not update book to the database !");
                            ModelState.AddModelError(string.Empty, "Update error please try again later !");
                        }
                    }
                }
                catch (ValidationException ex)
                {
                    _logger.LogWarning($"validation exception while edit book : {ex.ValidationResult.ErrorMessage}");
                    ModelState.AddModelError("", ex.ValidationResult.ErrorMessage);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Throw exception while edit book : {ex}");
                    ModelState.AddModelError("", "Error happend");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var currentBook = await _booksManager.GetByIdAsync(id);

                if (currentBook == null)
                {
                    return NotFound();
                }

                return View(_mapper.Map<BookViewModel>(currentBook));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting book with id of {id}");

                using (_booksManager)
                {
                    var currentData = await _booksManager.GetByIdAsync(id);
                    if (currentData == null)
                    {
                        _logger.LogWarning($"Can't find book with id of {id}");
                        return NotFound();
                    }

                    var deleteResult = await _booksManager.DeleteItemAsync(currentData.Id);
                    if (deleteResult.Status == RepositoryActionStatus.Deleted)
                    {
                        _logger.LogInformation("Book deleted successfully.");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        _logger.LogWarning("Could not delete book from the database !");
                        return BadRequest();
                    }

                }
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning($"validation exception while delete book : {ex.ValidationResult.ErrorMessage}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Throw exception while delete book : {ex}");
                throw ex;
            }
        }

        //[AcceptVerbs("Get", "Post")]
        //public async Task<IActionResult> VerifyCode(string code, int id = 0)
        //{
        //    try
        //    {
        //        var book = await _booksManager.GetBookByCode(code);

        //        if (book != null && book.Id != id)
        //        {
        //            return Json($"Sorry book code - {code} is already registered !");
        //        }
        //        return Json(true);
        //    }
        //    catch (Exception)
        //    {
        //        return Json("validation error ...!!");
        //    }
        //}

    }
}

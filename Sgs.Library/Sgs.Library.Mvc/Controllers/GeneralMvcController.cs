using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sameer.Shared;
using Sameer.Shared.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Library.Mvc.Controllers
{
    public class GeneralMvcController<M,VM> : Controller where M:class,ISameerObject,new() where VM:class,new()
    {
        protected readonly string _objectTypeName;
        protected IMapper _mapper;
        protected ILogger _logger;
        protected IDataManager<M>  _dataManager;

        #region Data Messages

        protected virtual string creatingNewDataMessage
        {
            get
            {
                return $"Creating a new {_objectTypeName}";
            }
        }

        protected virtual string creatingNewDataSuccessfullMessage
        {
            get
            {
                return $"{_objectTypeName} created successfully.";
            }
        }

        protected virtual string creatingNewDataFailMessage
        {
            get
            {
                return $"Could not save new {_objectTypeName} to the database !";
            }
        }

        protected virtual string saveErrorMessage
        {
            get
            {
                return $"Save error please try again later !";
            }
        }

        protected virtual string dataNotFoundMessage
        {
            get
            {
                return $"Can't find {_objectTypeName}";
            }
        }

        protected virtual string getDataNotFoundMessage(int id)
        {
            return $"Can't find {_objectTypeName} with id of {id}";
        }

        protected virtual string updatingDataMessage
        {
            get
            {
                return $"Updating {_objectTypeName}";
            }
        }

        protected virtual string getUpdatingDataMessage(int id)
        {
            return $"Updating {_objectTypeName} with id of {id}";
        }

        protected virtual string updatingDataSuccessfullMessage
        {
            get
            {
                return $"{_objectTypeName} updated successfully.";
            }
        }

        protected virtual string updatingDataFailMessage
        {
            get
            {
                return $"Could not save {_objectTypeName} to the database !";
            }
        }

        protected virtual string deletingDataMessage
        {
            get
            {
                return $"Deleting {_objectTypeName}";
            }
        }

        protected virtual string getDeletingDataMessage(int id)
        {
            return $"Deleting {_objectTypeName} with id of {id}";
        }

        protected virtual string deletingDataSuccessfullMessage
        {
            get
            {
                return $"{_objectTypeName} deleted successfully.";
            }
        }

        protected virtual string deletingDataFailMessage
        {
            get
            {
                return $"Could not delete {_objectTypeName} from the database !";
            }
        }

        #endregion

        public GeneralMvcController(string objectTypeName,IDataManager<M> dataManager
            , IMapper mapper, ILogger logger)
        {
            _objectTypeName = objectTypeName;
            _dataManager = dataManager;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public virtual IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual async Task<IActionResult> IndexAsync()
        {
            try
            {
                var allDataList = await _dataManager.GetAllDataList();
                return View(_mapper.Map<List<VM>>(allDataList));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public virtual async Task<IActionResult> Details(int id)
        {
            try
            {
                var currentData = await _dataManager.GetDataById(id);

                if (currentData == null)
                {
                    return NotFound();
                }

                return View(_mapper.Map<VM>(currentData));
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual async Task<M> createObject()
        {
            return await Task.FromResult(new M());
        }

        [HttpGet]
        public virtual async Task<IActionResult> Create()
        {
            try
            {
                return View(await createObject());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation(creatingNewDataMessage);

                    var validationResults = await checkNewData(model);
                    if (validationResults.Any())
                    {
                        foreach (var vr in validationResults)
                        {
                            foreach (var mn in vr.MemberNames)
                            {
                                _logger.LogWarning($"validation exception while saving new {_objectTypeName} :member name : {mn} error : {vr.ErrorMessage}");
                                ModelState.AddModelError(mn, vr.ErrorMessage);
                            }
                        }
                    }
                    else
                    {
                        var newData = _mapper.Map<M>(model);

                        using (_dataManager)
                        {

                            var saveResult = await _dataManager.InsertNewDataItem(newData);

                            if (saveResult.Status == RepositoryActionStatus.Created)
                            {
                                _logger.LogInformation(creatingNewDataSuccessfullMessage);
                                return createSucceededResult(saveResult.Entity);
                            }
                            else
                            {
                                _logger.LogWarning(creatingNewDataFailMessage);
                                ModelState.AddModelError(string.Empty, saveErrorMessage);
                            }

                        }
                    }
                }
                catch (ValidationException ex)
                {
                    _logger.LogWarning($"validation exception while saving new {_objectTypeName} : {ex.ValidationResult.ErrorMessage}");
                    ModelState.AddModelError("", ex.ValidationResult.ErrorMessage);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Throw exception while save new {_objectTypeName} : {ex}");
                    ModelState.AddModelError("", saveErrorMessage);
                }
            }

            return View(model);
        }

        protected virtual async Task<List<ValidationResult>> checkNewData(VM newData)
        {
            return await Task.FromResult(new List<ValidationResult>());
        }

        protected virtual IActionResult createSucceededResult(M newData)
        {
            return RedirectToAction(nameof(Details), new { id = newData.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var currentData = await _dataManager.GetDataById(id);

                if (currentData == null)
                {
                    return NotFound();
                }

                return View(_mapper.Map<VM>(currentData));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation(getUpdatingDataMessage(id));

                    using (_dataManager)
                    {
                        var currentData = await _dataManager.GetDataById(id);
                        if (currentData == null)
                        {
                            _logger.LogWarning(getDataNotFoundMessage(id));
                            return NotFound();
                        }

                        var validationResults = await checkEditData(currentData,model);
                        if (validationResults.Any())
                        {
                            foreach (var vr in validationResults)
                            {
                                foreach (var mn in vr.MemberNames)
                                {
                                    _logger.LogWarning($"validation exception while updating {_objectTypeName} :member name : {mn} error : {vr.ErrorMessage}");
                                    ModelState.AddModelError(mn, vr.ErrorMessage);
                                }
                            }
                        }
                        else
                        {
                            _mapper.Map(model, currentData);

                            var updateResult = await _dataManager.UpdateDataItem(currentData);
                            if (updateResult.Status == RepositoryActionStatus.Updated)
                            {
                                _logger.LogInformation(updatingDataSuccessfullMessage);
                                return editSucceededResult(updateResult.Entity);
                            }
                            else
                            {
                                _logger.LogWarning(updatingDataFailMessage);
                                ModelState.AddModelError(string.Empty, saveErrorMessage);
                            }
                        }                       
                    }
                }
                catch (ValidationException ex)
                {
                    _logger.LogWarning($"validation exception while edit {_objectTypeName} : {ex.ValidationResult.ErrorMessage}");
                    ModelState.AddModelError("", ex.ValidationResult.ErrorMessage);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Throw exception while edit {_objectTypeName} : {ex}");
                    ModelState.AddModelError("", saveErrorMessage);
                }
            }

            return View(model);
        }

        protected virtual async Task<List<ValidationResult>> checkEditData(M currentData,VM newData)
        {
            return await Task.FromResult(new List<ValidationResult>());
        }

        protected virtual IActionResult editSucceededResult(M currentData)
        {
            return RedirectToAction(nameof(Details), new { id = currentData.Id });
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var currentData = await _dataManager.GetDataById(id);

                if (currentData == null)
                {
                    return NotFound();
                }

                return View(_mapper.Map<VM>(currentData));
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
                _logger.LogInformation(getDeletingDataMessage(id));

                using (_dataManager)
                {
                    var currentData = await _dataManager.GetDataById(id);
                    if (currentData == null)
                    {
                        _logger.LogWarning(getDataNotFoundMessage(id));
                        return NotFound();
                    }

                    var validationResults = await checkDeleteData(currentData);
                    if (validationResults.Any())
                    {
                        foreach (var vr in validationResults)
                        {
                            foreach (var mn in vr.MemberNames)
                            {
                                _logger.LogWarning($"validation exception while deleting {_objectTypeName} :member name : {mn} error : {vr.ErrorMessage}");
                            }
                        }
                        return BadRequest();
                    }
                    else
                    {
                        var deleteResult = await _dataManager.DeleteDataItem(currentData.Id);
                        if (deleteResult.Status == RepositoryActionStatus.Deleted)
                        {
                            _logger.LogInformation(deletingDataSuccessfullMessage);
                            return deleteSucceededResult();
                        }
                        else
                        {
                            _logger.LogWarning(deletingDataFailMessage);
                            return BadRequest();
                        }
                    }
                }
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning($"validation exception while delete {_objectTypeName} : {ex.ValidationResult.ErrorMessage}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Throw exception while delete {_objectTypeName} : {ex}");
                throw ex;
            }
        }

        protected virtual async Task<List<ValidationResult>> checkDeleteData(M currentData)
        {
            return await Task.FromResult(new List<ValidationResult>());
        }

        protected virtual IActionResult deleteSucceededResult()
        {
            return RedirectToAction(nameof(Index));
        }

    }
}

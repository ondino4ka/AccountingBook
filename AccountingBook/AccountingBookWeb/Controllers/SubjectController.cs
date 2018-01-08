using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookWeb.BL.Attributes;
using AccountingBookWeb.Models;
using log4net;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class SubjectController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger("SubjectController");
        private readonly ISubjectProvider _subjectProvider;
        private readonly ISubjectService _subjectService;
        private readonly IFileService _fileService;
   
        public SubjectController(ISubjectProvider subjectProvider, ISubjectService subjectService, IFileService uploadService)
        {
            if (subjectProvider == null || subjectService == null || uploadService == null)
            {
                Log.Error("subjectProvider or subjectService or uploadService is null");
                throw new ArgumentNullException();
            }
            _subjectProvider = subjectProvider;
            _subjectService = subjectService;
            _fileService = uploadService;           
        }

        [Ajax]
        public PartialViewResult GetSubjectsByCategoryId(int? categoryId)
        {
            try
            {
                return PartialView("Subjects", _subjectProvider.GetSubjectsByCategoryId(categoryId));
            }
            catch (Exception)
            {
                return PartialView("Subjects");
            }
        }


        public ActionResult SearchSubjects()
        {
            return View();
        }

        [Ajax]
        public PartialViewResult ViewSubject(int inventoryNumber)
        {
            try
            {
                return PartialView(_subjectProvider.GetSubjectInformationByInventoryNumber(inventoryNumber));
            }
            catch (Exception)
            {
                return PartialView();
            }

        }

        [Ajax]
        public PartialViewResult GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            try
            {
                var subjects = _subjectProvider.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
                return PartialView("Subjects", subjects);
            }
            catch (Exception)
            {              
                return PartialView("Subjects");
            }
        }
       
        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult AddSubject()
        {
            return View(new SubjectViewModel());
        }


        [HttpPost]
        [Authorize(Roles = "Admin, Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult AddSubject(SubjectViewModel subjectViewModel)
        {
            try
            {
                if (_subjectProvider.IsExistsSubject(subjectViewModel.InventoryNumber))
                {
                    ModelState.AddModelError("InventoryNumber", "A subject with that InventoryNumber already exists");
                }
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View(subjectViewModel);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Subject subject = new Subject();
                    if (subjectViewModel.File != null)
                    {
                        _fileService.UploadPhoto(subjectViewModel.InventoryNumber.ToString(), subjectViewModel.File);
                        subject.Photo = subjectViewModel.InventoryNumber + Path.GetExtension(subjectViewModel.File.FileName);
                    }
                    subject.InventoryNumber = subjectViewModel.InventoryNumber;
                    subject.Name = subjectViewModel.Name;
                    subject.CategoryId = subjectViewModel.CategoryId;
                    subject.StateId = subjectViewModel.StateId;
                    subject.LocationId = subjectViewModel.LocationId;
                    subject.Description = subjectViewModel.Description;

                    _subjectService.AddSubject(subject);
                    return RedirectToAction("SearchSubjects");
                }
                catch (Exception exception)
                {
                    ViewBag.Error = exception.Message;
                    return View(subjectViewModel);
                }
            }
            return View(subjectViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]   
        public ActionResult EditSubjectInformation(int inventoryNumber)
        {
            try
            {
                Subject subject = _subjectProvider.GetSubjectByInventoryNumber(inventoryNumber);
                if (subject != null)
                {
                    return View(new SubjectViewModel(subject));
                }
                else
                {
                    return HttpNotFound();
                }

            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubjectInformation(SubjectViewModel subjectViewModel)
        {
            if (ModelState.IsValid)
            {
                Subject subject = new Subject();
                subject.InventoryNumber = subjectViewModel.InventoryNumber;
                subject.Name = subjectViewModel.Name;
                subject.CategoryId = subjectViewModel.CategoryId;
                subject.StateId = subjectViewModel.StateId;
                subject.LocationId = subjectViewModel.LocationId;
                subject.Description = subjectViewModel.Description;

                try
                {
                    _subjectService.EditSubjectInformation(subject);
                    return RedirectToAction("SearchSubjects");
                }
                catch (Exception exception)
                {
                    ViewBag.Error = exception.Message;
                    return View(subjectViewModel);
                }
            }
            return View(subjectViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult EditSubjectPhoto(int inventoryNumber)
        {
            try
            {
                SubjectDetails subject = _subjectProvider.GetSubjectInformationByInventoryNumber(inventoryNumber);
                if (subject != null)
                {
                    return View(new SubjectPhotoViewModel() { InventoryNumber = subject.InventoryNumber, Name = subject.Name, Photo = subject.Photo });
                }
                else
                {
                    return HttpNotFound();
                }

            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditSubjectPhoto(SubjectPhotoViewModel subjectPhoto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (subjectPhoto.File != null)
                    {
                        _fileService.UploadPhoto(subjectPhoto.InventoryNumber.ToString(), subjectPhoto.File);

                        _subjectService.EditSubjectPhoto(subjectPhoto.InventoryNumber, 
                            subjectPhoto.InventoryNumber.ToString() 
                            + Path.GetExtension(subjectPhoto.File.FileName));

                        return RedirectToAction("SearchSubjects");
                    }
                    else if (subjectPhoto.IsDelete)
                    {
                        _subjectService.EditSubjectPhoto(subjectPhoto.InventoryNumber, null);
                        _fileService.DeletePhoto(subjectPhoto.Photo);
                        return RedirectToAction("SearchSubjects");
                    }
                }
                catch (Exception exception)
                {
                    ViewBag.Error = exception.Message;
                    return View(subjectPhoto);
                }
            }
            return View(subjectPhoto);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult DeleteSubject(int inventoryNumber)
        {
            try
            {
                SubjectDetails subject = _subjectProvider.GetSubjectInformationByInventoryNumber(inventoryNumber);
                if (subject != null)
                {
                    return View(subject);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost, ActionName("DeleteSubject")]
        [Authorize(Roles = "Admin, Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int inventoryNumber, string Photo)
        {
            try
            {
                _subjectService.DeleteSubjectByInventoryNumber(inventoryNumber);
                if(!string.IsNullOrEmpty(Photo))
                {
                    _fileService.DeletePhoto(Photo);
                }
                return RedirectToAction("SearchSubjects");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult GetImageSubject(string name)
        {
            byte[] photo;
            string file_type = "image/" + name.Split('.').Last();
            string file_name = name;
            try
            {
                photo = _fileService.DownloadPhoto(name);
            }
            catch (Exception)
            {
                photo = new byte[] { };
            }
            return File(photo, file_type);
        }
    }
}
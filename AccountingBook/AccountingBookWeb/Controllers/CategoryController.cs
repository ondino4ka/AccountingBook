using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookWeb.BL.Attributes;
using log4net;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AccountingBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger("CategoryController");
        private readonly ICategoryProvider _categoryProvider;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryProvider categoryProvider, ICategoryService categoryService)
        {
            _categoryProvider = categoryProvider;
            _categoryService = categoryService;
        }

        [Ajax]
        public PartialViewResult CategoriesBar()
        {
            try
            {
                return PartialView(_categoryProvider.GetCategories().ToList());
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return PartialView();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult SearchCategories()
        {
            return View();
        }


        public PartialViewResult GetCategoriesByNamePartial(string categoryName)
        {
            try
            {
                return PartialView("Categories", _categoryProvider.GetCategoriesByName(categoryName));
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                return PartialView("Categories");
            }
        }
    
        [Ajax]
        public JsonResult GetCategoriesByName(string categoryName)
        {
            try
            {
                return Json(_categoryProvider.GetCategoriesByName(categoryName), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [Ajax]
        public JsonResult GetCategoriesBesidesCurrent(int categoryId)
        {
            try
            {
                return Json(_categoryProvider.GetCategoriesBesidesCurrent(categoryId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult AddEditCategory(int? categoryId)
        {
            if (!categoryId.HasValue)
            {
                return View(new Category());
            }

            try
            {
                Category category = _categoryProvider.GetCategoryById((int)categoryId);
                if (category != null)
                {
                    return View(category);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult AddEditCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name) || category.Name.Length > 50)
            {
                return View(category);
            }
            try
            {
                if (category.Id != 0)
                {
                    _categoryService.EditCategoryById(category.Id, category.Pid, category.Name);
                }
                else
                {
                    _categoryService.AddCategory(category.Pid, category.Name);
                }
                return RedirectToAction("SearchCategories");
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View(category);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult DeleteCategory(int categoryId)
        {
            try
            {
                Category category = _categoryProvider.GetCategoryById(categoryId);
                if (category != null)
                {
                    return View(category);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View();
            }
        }

        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Edit")]
        public ActionResult DeleteConfirmed(int categoryId)
        {
            try
            {
                _categoryService.DeleteCategoryByID(categoryId);
                return RedirectToAction("SearchCategories");
            }

            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
                return View();
            }
        }
    }
}
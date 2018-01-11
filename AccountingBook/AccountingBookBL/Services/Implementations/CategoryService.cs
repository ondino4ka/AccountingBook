using AccountingBookBL.Services.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;

namespace AccountingBookBL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            if (categoryRepository == null)
            {
                throw new ArgumentNullException("categoryRepository is null");
            }
            _categoryRepository = categoryRepository;
        }
        public void AddCategory(int? pid, string categoryName)
        {
            _categoryRepository.AddCategory(pid, categoryName);
        }

        public void EditCategoryById(int categoryId, int? pid, string categoryName)
        {
            _categoryRepository.EditCategoryById(categoryId, pid, categoryName);
        }

        public void DeleteCategoryByID(int categoryId)
        {
            _categoryRepository.DeleteCategoryById(categoryId);
        }
    }
}

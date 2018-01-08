using AccountingBookBL.Providers.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Implementations
{
    public class CategoryProvider: ICategoryProvider
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryProvider(ICategoryRepository categoryRepository)
        {
            if (categoryRepository == null)
            {
                throw new ArgumentException("categoryRepository is null");
            }
            _categoryRepository = categoryRepository;
        }
        public IReadOnlyList<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
        public IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId)
        {
            return _categoryRepository.GetCategoriesBesidesCurrent(categoryId);
        }
        public IReadOnlyCollection<Category> GetCategoriesByName(string categoryName)
        {
            return _categoryRepository.GetCategoriesByName(categoryName);
        }
        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }
    }
}

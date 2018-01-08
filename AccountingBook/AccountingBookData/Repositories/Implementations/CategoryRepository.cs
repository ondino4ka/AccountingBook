using AccountingBookCommon.Models;
using AccountingBookData.Clients.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookData.Repositories.Implementations
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ICategoryClient _categoryClient;
        public CategoryRepository(ICategoryClient categoryClient)
        {
            if (categoryClient == null)
            {
                throw new ArgumentException("categoryClient is null");
            }
            _categoryClient = categoryClient;
        }
        public IReadOnlyList<Category> GetCategories()
        {
            return _categoryClient.GetCategories();
        }
        public Category GetCategoryById(int categoryId)
        {
            return _categoryClient.GetCategoryById(categoryId);
        }

        public IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId)
        {
            return _categoryClient.GetCategoriesBesidesCurrent(categoryId);
        }

        public IReadOnlyCollection<Category> GetCategoriesByName(string categoryName)
        {
            return _categoryClient.GetCategoriesByName(categoryName);
        }

        public void AddCategory(int? pid, string categoryName)
        {
            _categoryClient.AddCategory(pid, categoryName);
        }

        public void EditCategoryById(int categoryId, int? pid, string categoryName)
        {
            _categoryClient.EditCategoryById(categoryId, pid, categoryName);
        }

        public void DeleteCategoryById(int categoryId)
        {
            _categoryClient.DeleteCategoryById(categoryId);
        }
    }
}

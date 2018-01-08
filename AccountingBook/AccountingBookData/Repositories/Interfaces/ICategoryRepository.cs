using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId);
        IReadOnlyCollection<Category> GetCategoriesByName(string category);
        Category GetCategoryById(int categoryId);
        void AddCategory(int? pid, string categoryName);
        void EditCategoryById(int categoryId, int? pid, string categoryName);
        void DeleteCategoryById(int categoryId);
    }
}

using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Interfaces
{
    public interface ICategoryProvider
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId);
        IReadOnlyList<Category> GetCategoriesByName(string category);
        Category GetCategoryById(int categoryId);
    }
}

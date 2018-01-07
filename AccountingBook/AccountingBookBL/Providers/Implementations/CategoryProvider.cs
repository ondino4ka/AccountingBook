using AccountingBookBL.Providers.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Implementations
{
    public class CategoryProvider: ICategoryProvider
    {
        private readonly IDataRepository _dataRepository;
        public CategoryProvider(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public IReadOnlyList<Category> GetCategories()
        {
            return _dataRepository.GetCategories();
        }
        public IReadOnlyList<Category> GetCategoriesBesidesCurrent(int categoryId)
        {
            return _dataRepository.GetCategoriesBesidesCurrent(categoryId);
        }
        public IReadOnlyCollection<Category> GetCategoriesByName(string categoryName)
        {
            return _dataRepository.GetCategoriesByName(categoryName);
        }
        public Category GetCategoryById(int categoryId)
        {
            return _dataRepository.GetCategoryById(categoryId);
        }
    }
}

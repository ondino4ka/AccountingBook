using AccountingBookBL.Services.Interfaces;
using AccountingBookData.Repositories;

namespace AccountingBookBL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IDataRepository _dataRepository;
        public CategoryService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public void AddCategory(int? pid, string categoryName)
        {
            _dataRepository.AddCategory(pid, categoryName);
        }

        public void EditCategoryById(int categoryId, int? pid, string categoryName)
        {
            _dataRepository.EditCategoryById(categoryId, pid, categoryName);
        }

        public void DeleteCategoryByID(int categoryId)
        {
            _dataRepository.DeleteCategoryById(categoryId);
        }

    }
}

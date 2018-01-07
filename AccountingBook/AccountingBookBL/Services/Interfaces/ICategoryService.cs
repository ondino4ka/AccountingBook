
namespace AccountingBookBL.Services.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(int? pid, string categoruName);
        void EditCategoryById(int categoryId, int? pid, string categoryName);
        void DeleteCategoryByID(int categoryId);
    }
}

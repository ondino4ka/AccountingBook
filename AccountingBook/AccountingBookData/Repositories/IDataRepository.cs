using System.Collections.Generic;
using AccountingBookCommon;

namespace AccountingBookData.Repositories
{
    public interface IDataRepository
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubCategory> GetSubCategories();
        IReadOnlyList<Subject> GetSubjects();
        IReadOnlyList<Subject> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory);
        Subject GetSubjectInformationById(int inventoryNumber);
    }
}

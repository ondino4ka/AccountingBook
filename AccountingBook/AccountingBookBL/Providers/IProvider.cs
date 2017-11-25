using AccountingBookCommon;
using System.Collections.Generic;

namespace AccountingBookBL.Providers
{
    public interface IProvider
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubCategory> GetSubCategories();
        IReadOnlyList<Subject> GetSubjects();
        IReadOnlyList<Subject> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory);
        Subject GetSubjectInformationById(int inventoryNumber);
    }
}

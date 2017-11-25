using AccountingBookCommon;
using System.Collections.Generic;

namespace AccountingBookData.Clients
{
    public interface IClient
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubCategory> GetSubCategories();
        IReadOnlyList<Subject> GetSubjects();
        IReadOnlyList<Subject> GetSubjectsByCategoryOrSubCategoryId(int categoryId, bool isCategory);
        Subject GetSubjectInformationById(int inventoryNumber);
    }
}

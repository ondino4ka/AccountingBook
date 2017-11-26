using AccountingBookCommon;
using System.Collections.Generic;

namespace AccountingBookData.Clients
{
    public interface IClient
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubCategory> GetSubCategories();
        IReadOnlyList<SubjectDetails> GetSubjects();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryOrSubCategoryId(int categoryId, bool isCategory);
        SubjectDetails GetSubjectInformationById(int inventoryNumber);
    }
}

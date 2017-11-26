using AccountingBookCommon;
using System.Collections.Generic;

namespace AccountingBookBL.Providers
{
    public interface IProvider
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubCategory> GetSubCategories();
        IReadOnlyList<SubjectDetails> GetSubjects();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory);
        SubjectDetails GetSubjectInformationById(int inventoryNumber);
    }
}

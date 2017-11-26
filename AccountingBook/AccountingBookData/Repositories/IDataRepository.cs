using System.Collections.Generic;
using AccountingBookCommon;

namespace AccountingBookData.Repositories
{
    public interface IDataRepository
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubCategory> GetSubCategories();
        IReadOnlyList<SubjectDetails> GetSubjects();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryOrSubCategoryId(int id, bool isCategory);
        SubjectDetails GetSubjectInformationById(int inventoryNumber);
    }
}

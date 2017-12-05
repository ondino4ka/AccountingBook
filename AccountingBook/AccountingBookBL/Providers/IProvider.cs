using System.Collections.Generic;
using AccountingBookCommon;

namespace AccountingBookBL.Providers
{
    public interface IProvider
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubjectDetails> GetSubjects();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int categoryId);
        SubjectDetails GetSubjectInformationById(int inventoryNumber);
    }
}

using System.Collections.Generic;
using AccountingBookCommon.Models;

namespace AccountingBookBL.Providers
{
    public interface IProvider
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubjectDetails> GetSubjects();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int categoryId);
        SubjectDetails GetSubjectInformationById(int inventoryNumber);
        IReadOnlyCollection<Category> GetCategoriesByName(string category);
        IReadOnlyCollection<SubjectDetails> GetSubjectByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);
        IReadOnlyCollection<State> GetStates();
    }
}

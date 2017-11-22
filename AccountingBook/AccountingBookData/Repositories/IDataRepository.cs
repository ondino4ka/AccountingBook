using System.Collections.Generic;
using AccountingBookCommon;

namespace AccountingBookData.Repositories
{
    public interface IDataRepository
    {
        IReadOnlyList<Subject> GetSubjects();
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubCategory> GetSubCategories();
        Subject GetSubjectInformationById(int inventoryNumberSubject);
    }
}

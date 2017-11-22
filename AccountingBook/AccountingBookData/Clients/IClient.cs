using AccountingBookCommon;
using System.Collections.Generic;

namespace AccountingBookData.Clients
{
    public interface IClient
    {
        IReadOnlyList<Subject> GetSubjects();
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubCategory> GetSubCategories();
        Subject GetSubjectInformationById(int inventoryNumberSubject);
    }
}

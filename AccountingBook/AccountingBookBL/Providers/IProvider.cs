using AccountingBookCommon;
using System.Collections.Generic;

namespace AccountingBookBL.Providers
{
    public interface IProvider
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<Subject> GetSubjects();
        IReadOnlyList<Subject> GetSubjectsBySubCategories(int idSubCategories);
        IReadOnlyList<Subject> GetSubjectsByCategories(int idCategories);
        Subject GetSubjectInformationById(int inventoryNumberSubject);
        string GetNameSubCategoryBySubjectId(int inventoryNumberSubject);

    }
}

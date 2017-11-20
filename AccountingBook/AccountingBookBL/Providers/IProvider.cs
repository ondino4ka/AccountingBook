using AccountingBookCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBookBL
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

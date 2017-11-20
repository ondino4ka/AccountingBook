using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingBookCommon;

namespace AccountingBookData.Repositories
{
    public interface IDataProvider
    {
        IReadOnlyList<Subject> GetSubjects();
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubCategory> GetSubCategories();
        Subject GetSubjectInformationById(int inventoryNumberSubject);
    }
}

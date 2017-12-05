using System.Collections.Generic;
using AccountingBookCommon;
using AccountingBookCommon.Models;

namespace AccountingBookData.Clients
{
    public interface IClient
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubjectDetails> GetSubjects();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int categoryId);
        SubjectDetails GetSubjectInformationById(int inventoryNumber);
        User GetUserByName(string userName);
        bool IsValidUser(string userName, string password);    
    }
}

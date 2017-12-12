using System.Collections.Generic;
using AccountingBookCommon;
using AccountingBookCommon.Models;

namespace AccountingBookData.Clients
{
    public interface IClient
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int categoryId);
        SubjectDetails GetSubjectInformationById(int inventoryNumber);
        UserAuthorization GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
        IReadOnlyCollection<Category> GetCategoriesByName(string categoryName);
        IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);
        IReadOnlyCollection<State> GetStates();
        void AddUser(User user);
        bool IsExistsUser(int userId, string userName);
        IReadOnlyCollection<Role> GetRoles();
        User GetUserById(int userId);
        void EditUser(User user);
        IReadOnlyCollection<User> GetUsersByName(string userName);
        void DeleteUser(int userId);
    }
}

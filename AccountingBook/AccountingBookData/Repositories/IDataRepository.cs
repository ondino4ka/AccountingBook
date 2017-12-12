using System.Collections.Generic;
using AccountingBookCommon;
using AccountingBookCommon.Models;

namespace AccountingBookData.Repositories
{
    public interface IDataRepository
    {
        IReadOnlyList<Category> GetCategories();
        IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int categoryId);
        SubjectDetails GetSubjectInformationById(int inventoryNumber);
        UserAuthorization GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
        IReadOnlyCollection<Category> GetCategoriesByName(string category);
        IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName);
        IReadOnlyCollection<State> GetStates();
        void AddUser(User user);
        void EditUser(User user);
        bool IsExistsUser(int userId, string userName);
        IReadOnlyCollection<Role> GetRoles();
        User GetUserById(int userId);
        IReadOnlyCollection<User> GetUsersByName(string userName);
        void DeleteUser(int userId);
    }
}

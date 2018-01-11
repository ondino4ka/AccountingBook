using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserAuthorization GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUserById(int userId);
        bool IsExistsUser(int userId, string userName);
        IReadOnlyList<Role> GetRoles();
        User GetUserById(int userId);
        IReadOnlyList<User> GetUsersByName(string userName);
    }
}

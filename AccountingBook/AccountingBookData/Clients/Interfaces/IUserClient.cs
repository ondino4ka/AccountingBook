using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookData.Clients.Interfaces
{
    public interface IUserClient
    {
        UserAuthorization GetUserByName(string userName);
        bool IsValidUser(string userName, string password);
        void AddUser(User user);
        bool IsExistsUser(int userId, string userName);
        IReadOnlyList<Role> GetRoles();
        User GetUserById(int userId);
        void EditUser(User user);
        IReadOnlyList<User> GetUsersByName(string userName);
        void DeleteUserById(int userId);
    }
}

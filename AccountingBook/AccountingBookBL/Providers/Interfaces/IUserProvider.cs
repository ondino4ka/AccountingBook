using AccountingBookCommon.Models;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Interfaces
{
    public interface IUserProvider
    {
        bool IsValidUser(string userName, string password);
        UserAuthorization GetUserByName(string userName);
        bool IsExistsUser(int userId, string userName);
        IReadOnlyList<Role> GetRoles();
        User GetUserById(int userId);
        IReadOnlyList<User> GetUsersByName(string userName);
    }
}

using System.Collections.Generic;
using AccountingBookCommon.Models;

namespace AccountingBookBL.Providers
{
    public interface IUserProvider
    {
        bool IsValidUser(string userName, string password);
        UserAuthorization GetUserByName(string userName);
        bool IsExistsUser(int userId, string userName);
        IReadOnlyCollection<Role> GetRoles();
        User GetUserById(int userId);
        IReadOnlyCollection<User> GetUsersByName(string userName);
    }
}

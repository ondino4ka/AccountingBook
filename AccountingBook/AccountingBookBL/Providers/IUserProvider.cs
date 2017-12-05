using AccountingBookCommon.Models;

namespace AccountingBookBL.Providers
{
    public interface IUserProvider
    {
        bool IsValidUser(string userName, string password);
        User GetUserByName(string userName);
    }
}

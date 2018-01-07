using AccountingBookCommon.Models;

namespace AccountingBookBL.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void EditUser(User user);
        void EditUserInformation(User user);
        void DeleteUserById(int userId);
    }
}

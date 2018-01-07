using AccountingBookCommon.Enums;

namespace AccountingBookBL.Services.Interfaces
{
    public interface ILoginService
    {
        LoginResult Login(string userName, string password);
        void Logout();
    }
}

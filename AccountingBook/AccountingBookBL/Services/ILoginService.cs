using AccountingBookCommon.Enums;

namespace AccountingBookBL.Services
{
    public interface ILoginService
    {
        LoginResult Login(string userName, string password);
        void Logout();
    }
}

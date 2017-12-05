using AccountingBookCommon.Models;
using AccountingBookData.Repositories;

namespace AccountingBookBL.Providers
{
    public class UserProvider : IUserProvider
    {
        IDataRepository _dataRepository;
        public UserProvider(IDataRepository dataProvider)
        {
            _dataRepository = dataProvider;
        }
        public User GetUserByName(string userName)
        {        
            return _dataRepository.GetUserByName(userName);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _dataRepository.IsValidUser(userName, password);
        }
    }
}

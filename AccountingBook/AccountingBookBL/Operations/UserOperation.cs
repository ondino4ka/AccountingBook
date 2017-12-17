using AccountingBookCommon.Models;
using AccountingBookData.Repositories;

namespace AccountingBookBL.Operations
{
    public class UserOperation : IUserOperation
    {
        private readonly IDataRepository _dataRepository;
        public UserOperation(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public void AddUser(User user)
        {
            _dataRepository.AddUser(user);
        }

        public void DeleteUserById(int userId)
        {
            _dataRepository.DeleteUserById(userId);
        }

        public void EditUser(User user)
        {
            _dataRepository.EditUser(user);
        }
    }
}

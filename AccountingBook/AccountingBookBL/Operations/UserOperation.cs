using System;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories;

namespace AccountingBookBL.Operations
{
    public class UserOperation : IUserOperation
    {
        IDataRepository _dataRepository;
        public UserOperation(IDataRepository dataProvider)
        {
            _dataRepository = dataProvider;
        }
        public void AddUser(User user)
        {
            _dataRepository.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            _dataRepository.DeleteUser(userId);
        }

        public void EditUser(User user)
        {
            _dataRepository.EditUser(user);
        }
    }
}

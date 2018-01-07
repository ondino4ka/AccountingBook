using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories;

namespace AccountingBookBL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IDataRepository _dataRepository;
        private readonly IHashService _hashService;
        public UserService(IDataRepository dataRepository, IHashService hashService)
        {
            _dataRepository = dataRepository;
            _hashService = hashService;
        }
        public void AddUser(User user)
        {
            user.Password = _hashService.GetHash(user.Password);
            _dataRepository.AddUser(user);
        }

        public void DeleteUserById(int userId)
        {
            _dataRepository.DeleteUserById(userId);
        }

        public void EditUser(User user)
        {
            user.Password = _hashService.GetHash(user.Password);
            _dataRepository.EditUser(user);
        }
        public void EditUserInformation(User user)
        {
            _dataRepository.EditUser(user);
        }
    }
}

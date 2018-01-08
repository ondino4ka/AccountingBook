using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories.Interfaces;
using System;

namespace AccountingBookBL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;
        public UserService(IUserRepository userRepository, IHashService hashService)
        {
            if (userRepository == null || hashService == null)
            {
                throw new ArgumentException("userRepository or hashService is null");
            }
            _userRepository = userRepository;
            _hashService = hashService;
        }
        public void AddUser(User user)
        {
            user.Password = _hashService.GetHash(user.Password);
            _userRepository.AddUser(user);
        }

        public void DeleteUserById(int userId)
        {
            _userRepository.DeleteUserById(userId);
        }

        public void EditUser(User user)
        {
            user.Password = _hashService.GetHash(user.Password);
            _userRepository.EditUser(user);
        }
        public void EditUserInformation(User user)
        {
            _userRepository.EditUser(user);
        }
    }
}

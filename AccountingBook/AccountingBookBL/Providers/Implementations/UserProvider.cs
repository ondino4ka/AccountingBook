using AccountingBookBL.Providers.Interfaces;
using AccountingBookCommon.Models;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookBL.Providers.Implementations
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;
        public UserProvider(IUserRepository userRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException("userRepository is null");
            }
            _userRepository = userRepository;
        }
        public UserAuthorization GetUserByName(string userName)
        {        
            return _userRepository.GetUserByName(userName);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _userRepository.IsValidUser(userName, password);
        }
        public bool IsExistsUser(int userId, string userName)
        {
            return _userRepository.IsExistsUser(userId, userName);
        } 
        public IReadOnlyList<Role> GetRoles()
        {
            return _userRepository.GetRoles();
        }
        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public IReadOnlyList<User> GetUsersByName(string userName)
        {
            return _userRepository.GetUsersByName(userName);
        }
    }
}

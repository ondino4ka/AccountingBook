using AccountingBookCommon.Models;
using AccountingBookData.Clients.Interfaces;
using AccountingBookData.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace AccountingBookData.Repositories.Implementations
{
    public class UserRepository: IUserRepository
    {
        private readonly IUserClient _userClient;
        public UserRepository(IUserClient userClient)
        {
            if (userClient == null)
            {
                throw new ArgumentNullException("userClient is null");
            }
            _userClient = userClient;
        }

        public UserAuthorization GetUserByName(string userName)
        {
            return _userClient.GetUserByName(userName);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _userClient.IsValidUser(userName, password);
        }

        public bool IsExistsUser(int userId, string userName)
        {
            return _userClient.IsExistsUser(userId, userName);
        }

        public void AddUser(User user)
        {
            _userClient.AddUser(user);
        }
        public void EditUser(User user)
        {
            _userClient.EditUser(user);
        }
        public IReadOnlyList<Role> GetRoles()
        {
            return _userClient.GetRoles();
        }
        public User GetUserById(int userId)
        {
            return _userClient.GetUserById(userId);
        }

        public IReadOnlyList<User> GetUsersByName(string userName)
        {
            return _userClient.GetUsersByName(userName);
        }

        public void DeleteUserById(int userId)
        {
            _userClient.DeleteUserById(userId);
        }
    }
}

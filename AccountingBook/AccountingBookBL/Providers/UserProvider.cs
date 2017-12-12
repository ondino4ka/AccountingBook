﻿using System;
using System.Collections.Generic;
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
        public UserAuthorization GetUserByName(string userName)
        {        
            return _dataRepository.GetUserByName(userName);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _dataRepository.IsValidUser(userName, password);
        }
        public bool IsExistsUser(int userId, string userName)
        {
            return _dataRepository.IsExistsUser(userId, userName);
        } 
        public IReadOnlyCollection<Role> GetRoles()
        {
            return _dataRepository.GetRoles();
        }
        public User GetUserById(int userId)
        {
            return _dataRepository.GetUserById(userId);
        }

        public IReadOnlyCollection<User> GetUsersByName(string userName)
        {
            return _dataRepository.GetUsersByName(userName);
        }
    }
}

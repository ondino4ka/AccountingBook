using System;
using System.Collections.Generic;
using AccountingBookCommon;
using AccountingBookData.Clients;
using AccountingBookCommon.Models;

namespace AccountingBookData.Repositories
{
    public class DataRepository : IDataRepository
    {
        IClient _client;
        public DataRepository(IClient client)
        {
            _client = client;
        }

        public IReadOnlyList<Category> GetCategories()
        {
            return _client.GetCategories();
        }


        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int categoryId)
        {
            return _client.GetSubjectsByCategoryId(categoryId);
        }

        public SubjectDetails GetSubjectInformationById(int inventoryNumber)
        {
            return _client.GetSubjectInformationById(inventoryNumber);
        }

        public UserAuthorization GetUserByName(string userName)
        {
            return _client.GetUserByName(userName);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _client.IsValidUser(userName, password);
        }

        public bool IsExistsUser(int userId, string userName)
        {
            return _client.IsExistsUser(userId, userName);
        }

        public IReadOnlyCollection<Category> GetCategoriesByName(string categoryName)
        {
            return _client.GetCategoriesByName(categoryName);
        }

        public IReadOnlyCollection<SubjectDetails> GetSubjectsByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            return _client.GetSubjectsByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
        }

        public IReadOnlyCollection<State> GetStates()
        {
            return _client.GetStates();
        }
        public void AddUser(User user)
        {
            _client.AddUser(user);
        }
        public void EditUser(User user)
        {
            _client.EditUser(user);
        }
        public IReadOnlyCollection<Role> GetRoles()
        {
            return _client.GetRoles();
        }
        public User GetUserById(int userId)
        {
            return _client.GetUserById(userId);
        }

        public IReadOnlyCollection<User> GetUsersByName(string userName)
        {
            return _client.GetUsersByName(userName);
        }

        public void DeleteUser(int userId)
        {
            _client.DeleteUser(userId);
        }
    }
}

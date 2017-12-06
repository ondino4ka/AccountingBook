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

        public IReadOnlyList<SubjectDetails> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryId(int categoryId)
        {
            return _client.GetSubjectsByCategoryId(categoryId);
        }

        public SubjectDetails GetSubjectInformationById(int inventoryNumber)
        {
            return _client.GetSubjectInformationById(inventoryNumber);
        }

        public User GetUserByName(string userName)
        {
            return _client.GetUserByName(userName);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _client.IsValidUser(userName, password);
        }
        public IReadOnlyCollection<Category> GetCategoriesByName(string categoryName)
        {
            return _client.GetCategoriesByName(categoryName);
        }

        public IReadOnlyCollection<SubjectDetails> GetSubjectByNameCategoryIdAndStateId(int? categoryId, int? stateId, string subjectName)
        {
            return _client.GetSubjectByNameCategoryIdAndStateId(categoryId, stateId, subjectName);
        }

        public IReadOnlyCollection<State> GetStates()
        {
            return _client.GetStates();
        }
    }
}

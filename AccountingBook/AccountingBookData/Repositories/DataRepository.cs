using System;
using System.Collections.Generic;
using AccountingBookCommon;
using AccountingBookData.Clients;

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

        public IReadOnlyList<SubCategory> GetSubCategories()
        {
            return _client.GetSubCategories();
        }

        public IReadOnlyList<SubjectDetails> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SubjectDetails> GetSubjectsByCategoryOrSubCategoryId(int categoryId, bool isCategiory)
        {
            return _client.GetSubjectsByCategoryOrSubCategoryId(categoryId, isCategiory);
        }

        public SubjectDetails GetSubjectInformationById(int inventoryNumber)
        {
            return _client.GetSubjectInformationById(inventoryNumber);
        }

     
    }
}

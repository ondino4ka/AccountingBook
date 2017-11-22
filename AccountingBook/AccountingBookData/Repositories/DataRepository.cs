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

        public Subject GetSubjectInformationById(int inventoryNumberSubject)
        {
            return _client.GetSubjectInformationById(inventoryNumberSubject);
        }

        public IReadOnlyList<Subject> GetSubjects()
        {
            return _client.GetSubjects();
        }
    }
}

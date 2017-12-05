using StructureMap.Configuration.DSL;
using AccountingBookData.Clients;
using AccountingBookData.Repositories;

namespace AccountingBookData.Container
{
    public class DataRegistry:Registry
    {
        public DataRegistry()
        {
            For<IClient>().Use<Client>();
            For<IDataRepository>().Use<DataRepository>();
        }
    }
}

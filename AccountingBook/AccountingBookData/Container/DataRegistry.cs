using AccountingBookData.Clients;
using AccountingBookData.Repositories;
using StructureMap.Configuration.DSL;

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

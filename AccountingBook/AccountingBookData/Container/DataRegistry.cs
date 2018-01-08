using AccountingBookData.Clients.Implementations;
using AccountingBookData.Clients.Interfaces;
using AccountingBookData.Repositories.Implementations;
using AccountingBookData.Repositories.Interfaces;
using log4net;
using StructureMap.Configuration.DSL;

namespace AccountingBookData.Container
{
    public class DataRegistry:Registry
    {
        public DataRegistry()
        {
            For<ISubjectRepository>().Use<SubjectRepository>();
            For<ICategoryRepository>().Use<CategoryRepository>();
            For<ILocationRepository>().Use<LocationRepository>();
            For<IStateRepository>().Use<StateRepository>();
            For<IUserRepository>().Use<UserRepository>();
            For<IFileRepository>().Use<FileRepository>();

            For<ISubjectClient>().Use<SubjectClient>();
            For<ICategoryClient>().Use<CategoryClient>();
            For<ILocationClient>().Use<LocationClient>();
            For<IStateClient>().Use<StateClient>();
            For<IUserClient>().Use<UserClient>();
            For<IFileClient>().Use<FileClient>();
        }
    }
}

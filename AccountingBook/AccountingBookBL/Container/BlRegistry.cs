using AccountingBookBL.Providers.Implementations;
using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Implementations;
using AccountingBookBL.Services.Interfaces;
using StructureMap.Configuration.DSL;

namespace AccountingBookBL.Container
{
    public class BlRegistry : Registry
    {
        public BlRegistry()
        {
            For<ISubjectProvider>().Use<SubjectProvider>();
            For<ICategoryProvider>().Use<CategoryProvider>();       
            For<ILocationProvider>().Use<LocationProvider>();
            For<IStateProvider>().Use<StateProvider>();      
            For<IUserProvider>().Use<UserProvider>();

            For<ISubjectService>().Use<SubjectService>();
            For<ICategoryService>().Use<CategoryService>();
            For<ILoginService>().Use<LoginService>();
            For<IUserService>().Use<UserService>();       
            For<ILocationService>().Use<LocationService>();
            For<IStateService>().Use<StateService>();           
            For<IFileService>().Use<FileService>();
            For<IHashService>().Use<HashService>();
        }
    }
}

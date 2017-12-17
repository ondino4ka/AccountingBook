using AccountingBookBL.Operations;
using AccountingBookBL.Providers;
using AccountingBookBL.Services;
using StructureMap.Configuration.DSL;

namespace AccountingBookBL.Container
{
    public class BlRegistry : Registry
    {
        public BlRegistry()
        {
            For<IProvider>().Use<Provider>();
            For<IUserProvider>().Use<UserProvider>();
            For<ILoginService>().Use<LoginService>();
            For<IUserOperation>().Use<UserOperation>();
            For<ISubjectOperation>().Use<SubjectOperation>();
            For<ILocationOperation>().Use<LocationOperation>();
            For<IStateOperation>().Use<StateOperation>();
            For<IFileService>().Use<FileService>();
        }
    }
}

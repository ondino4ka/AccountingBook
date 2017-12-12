using StructureMap.Configuration.DSL;
using AccountingBookBL.Providers;
using AccountingBookBL.Services;
using AccountingBookBL.Operations;

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
        }
    }
}

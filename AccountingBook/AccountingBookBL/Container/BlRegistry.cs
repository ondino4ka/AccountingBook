using AccountingBookBL.Providers;
using StructureMap.Configuration.DSL;

namespace AccountingBookBL.Container
{
    public class BlRegistry : Registry
    {
        public BlRegistry()
        {
            For<IProvider>().Use<Provider>();
        }
    }
}

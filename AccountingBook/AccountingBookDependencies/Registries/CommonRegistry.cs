using AccountingBookBL.Container;
using AccountingBookData.Container;
using StructureMap.Configuration.DSL;

namespace AccountingBookDependencies.Registries
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            Scan(scan => {
                scan.Assembly(typeof(DataRegistry).Assembly);
                scan.Assembly(typeof(BlRegistry).Assembly);
                scan.WithDefaultConventions();
            });
        }
    }
}

using StructureMap.Configuration.DSL;
using AccountingBookBL.Container;
using AccountingBookData.Container;

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

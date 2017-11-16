using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBookBL
{
    public class Class1 : IDependency
    {
        public string GetMessages()
        {            
            return "Hello World";
        }
    }
}

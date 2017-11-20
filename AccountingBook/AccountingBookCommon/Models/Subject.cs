using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBookCommon
{
    public class Subject
    {
        public int InventoryNumber { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public int IdSubCategory { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}

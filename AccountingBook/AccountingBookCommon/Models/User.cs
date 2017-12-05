using System.Collections.Generic;

namespace AccountingBookCommon.Models
{
    public class User
    {
        public string UserName { get; set; }
        public List<Role> Roles { get; set; }
    }
}

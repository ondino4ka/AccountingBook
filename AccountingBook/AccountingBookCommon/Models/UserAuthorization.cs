using System.Collections.Generic;

namespace AccountingBookCommon.Models
{
    public class UserAuthorization
    {
        public string Name { get; set; }
        public List<RoleAuthorization> Roles { get; set; }
    }
}

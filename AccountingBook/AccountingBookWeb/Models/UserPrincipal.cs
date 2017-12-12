using System.Linq;
using System.Security.Principal;

namespace AccountingBookWeb.Models
{
    public class UserPrincipal : IPrincipal
    {
        public string Name { get; set; }
        public string[] Roles { get; set; }
        public IIdentity Identity{ get; private set; }

        public UserPrincipal(string name)
        {
            Identity = new GenericIdentity(name);
        }

        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}
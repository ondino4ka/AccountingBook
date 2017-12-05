using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AccountingBookService.Contracts.Models.Dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public List<RoleDto> Roles { get; set; }
    }
}

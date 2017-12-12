using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AccountingBookService.Contracts.Models.Dto
{
    [DataContract]
    public class UserAuthorizationDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<RoleAuthorizationDto> Roles { get; set; }
    }
}

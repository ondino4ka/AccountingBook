using System;using System.Runtime.Serialization;

namespace AccountingBookService.Contracts.Models.Dto
{
    [DataContract]
    public class RoleAuthorizationDto
    {
        [DataMember]
        public string RoleName { get; set; }
    }
}

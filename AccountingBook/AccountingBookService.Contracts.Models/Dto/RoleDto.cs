using System;using System.Runtime.Serialization;

namespace AccountingBookService.Contracts.Models.Dto
{
    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public string RoleName { get; set; }
    }
}

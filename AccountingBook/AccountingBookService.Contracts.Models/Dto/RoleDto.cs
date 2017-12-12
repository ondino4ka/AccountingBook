using System.Runtime.Serialization;


namespace AccountingBookService.Contracts.Models.Dto
{
    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

}

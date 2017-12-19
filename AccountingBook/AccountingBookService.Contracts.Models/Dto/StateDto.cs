using System.Runtime.Serialization;

namespace AccountingBookService.Contracts.Models.Dto
{
    [DataContract]
    public class StateDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StateName { get; set; }
    }
}

using System.Runtime.Serialization;


namespace AccountingBookService.Contracts.Models.Dto
{
    [DataContract]
    public class LocationDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
}
using System.Runtime.Serialization;


namespace AccountingBookService.Contracts.Models.Dto
{
    [DataContract]
    public class SubjectDto
    {
        [DataMember]
        public int InventoryNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? LocationId { get; set; }
        [DataMember]
        public int? StateId { get; set; }
        [DataMember]
        public int? CategoryId { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}


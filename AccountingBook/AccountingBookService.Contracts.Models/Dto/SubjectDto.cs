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
        public string Location { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public int IdSubCategory { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}

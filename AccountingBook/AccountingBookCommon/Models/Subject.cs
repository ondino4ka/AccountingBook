
namespace AccountingBookCommon.Models
{
    public class Subject
    {
        public int InventoryNumber { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public int? StateId { get; set; }
        public int? CategoryId { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}

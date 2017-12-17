using System.Web;

namespace AccountingBookWeb.Models
{
    public class SubjectPhotoViewModel
    {
        public int InventoryNumber { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public bool IsDelete { get; set; }
        [BL.Attributes.FileExtensions("jpg,jpeg,png",
         ErrorMessage = "Specify a image file. (jpg,jpeg,png)")]
        public HttpPostedFileBase File { get; set; }
    }
}
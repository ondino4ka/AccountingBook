using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AccountingBookCommon.Models;
using System.Web;
using AccountingBookWeb.BL.Attributes;

namespace AccountingBookWeb.Models
{
    public class SubjectViewModel
    {
        [Range(1, 999999999, ErrorMessage = "Invalid number(1-99999999)")]
        public int InventoryNumber { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [DisplayName("State")]
        public int? StateId { get; set; }
        [DisplayName("Category")]
        public int? CategoryId { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }
        [DisplayName("Address")]
        public int? LocationId { get; set; }

        [BL.Attributes.FileExtensions("jpg,jpeg,png",
           ErrorMessage = "Specify a image file. (jpg,jpeg,png)")]    
        public HttpPostedFileBase File { get; set; }

        public SubjectViewModel()
        {

        }

        public SubjectViewModel(Subject subject)
        {
            InventoryNumber = subject.InventoryNumber;
            Name = subject.Name;
            StateId = subject.StateId;
            CategoryId = subject.CategoryId;
            Photo = subject.Photo;
            Description = subject.Description;
            LocationId = subject.LocationId;
        }

    }
}
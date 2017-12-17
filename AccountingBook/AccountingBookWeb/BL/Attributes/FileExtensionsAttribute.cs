using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountingBookWeb.BL.Attributes
{
    public class FileExtensionsAttribute : ValidationAttribute
    {
        private string [] AllowedExtensions { get; set; }

        public FileExtensionsAttribute(string fileExtensions)
        {
            AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        public override bool IsValid(object value)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;

            if (file != null)
            {
                return AllowedExtensions.Any(y => file.FileName.EndsWith(y));
            }

            return true;
        }
    }
}
using AccountingBookCommon.Models;
using AccountingBookWeb.BL.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AccountingBookWeb.Models
{
    public class UserWithoutPassViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "The field does not contain a valid email address")]
        public string Email { get; set; }

        [RequiredArray(ErrorMessage = "Can not be empty")]
        public int[] Roles { get; set; }

        public UserWithoutPassViewModel()
        {
            Roles = new int[] { };
        }
        public UserWithoutPassViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;          
            Roles = user.Roles;
        }
    }
}
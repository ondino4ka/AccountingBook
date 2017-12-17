using AccountingBookCommon.Models;
using AccountingBookWeb.BL.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AccountingBookWeb.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "The field does not contain a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Passsword")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string RePassword { get; set; }

        [RequiredArray(ErrorMessage = "Can not be empty")]
        public int [] Roles { get; set; }

        public UserViewModel()
        {
            Roles = new int[] { };
        }
        public UserViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            RePassword = user.Password;
            Roles = user.Roles;
        }
    }
}
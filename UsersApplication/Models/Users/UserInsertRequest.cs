using System.ComponentModel.DataAnnotations;

namespace UsersApplication.Models.Users
{
    public class UserInsertRequest
    {
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required"),
         EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}

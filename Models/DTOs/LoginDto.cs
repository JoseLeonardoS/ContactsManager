using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Models.DTOs
{
    public class LoginDto
    {

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The Password must be between 8 and 50 characters.")]
        public string? Password { get; set; }
    }
}

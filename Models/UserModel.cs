using System.ComponentModel.DataAnnotations;

namespace ContactsManager.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The Name must be between 3 and 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The Password must be between 8 and 50 characters.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "The Phone field is required.")]
        [RegularExpression(@"^(\+55)?\s?(\(?\d{2}\)?)\s?\d{4,5}-?\d{4}$", ErrorMessage = "Invalid Phone number format.")]
        public string? Phone { get; set; }
    }
}

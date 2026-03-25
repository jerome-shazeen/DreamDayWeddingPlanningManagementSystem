using System.ComponentModel.DataAnnotations;

namespace DreamDayWeddingPlanningManagementSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; } = string.Empty;

        // This field distinguishes couples from other user types (like planners)
        public string Role { get; set; } = "Couple";
    }
}

using System.ComponentModel.DataAnnotations;
using TheReader.Infrastructure.Data.Models.Enums;

namespace TheReader.Core.Models.User
{
    public class ProfileViewModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public GenderType? Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

    }
}

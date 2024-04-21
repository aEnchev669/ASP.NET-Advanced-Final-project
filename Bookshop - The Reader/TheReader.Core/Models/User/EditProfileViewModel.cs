using System.ComponentModel.DataAnnotations;
using TheReader.Infrastructure.Data.Models.Enums;
using static TheReader.Infrastructure.Constants.DataConstants.ApplicationUserConstants;
using static TheReader.Infrastructure.Constants.ErrorMessages.UserErrorMessage;

namespace TheReader.Core.Models.User
{
	public class EditProfileViewModel
	{
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = InvalidUsername)]
        public string UserName { get; set; } = string.Empty;

        public string? FirstName { get; set; } 
        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public GenderType? Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}

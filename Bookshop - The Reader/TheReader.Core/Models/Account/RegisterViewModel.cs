using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.DataConstants.ApplicationUserConstants;
using static TheReader.Infrastructure.Constants.ErrorMessages;

namespace TheReader.Core.Models.Account
{
	public class RegisterViewModel
	{
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = UserErrorMessage.InvalidUsername)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}

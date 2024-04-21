using System.ComponentModel.DataAnnotations;
using static TheReader.Infrastructure.Constants.ErrorMessages.GeneralError;
namespace TheReader.Core.Models.User
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = GeneralRequiredErrorMessage)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = null!;

        [Required(ErrorMessage = GeneralRequiredErrorMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; } = null!;

        [Required(ErrorMessage = GeneralRequiredErrorMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}

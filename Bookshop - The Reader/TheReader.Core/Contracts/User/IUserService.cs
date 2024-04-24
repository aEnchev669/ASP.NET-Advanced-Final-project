using TheReader.Core.Models.User;

namespace TheReader.Core.Contracts.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();

        Task<IEnumerable<UserViewModel>> GetAllUsersExceptCurrOneAsync(string userId);

        Task<EditProfileViewModel> GetUserByIdAsync(string userId);

        Task EditProfileAsync(string userId, EditProfileViewModel model);

        Task SoftDeleteUserAsync(string userId);

        Task<bool> IsUserDeletedAsync(string userId);
    }
}

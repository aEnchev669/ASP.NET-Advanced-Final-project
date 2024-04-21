namespace TheReader.Core.Models.User
{
	public class UserViewModel
	{
        public string Id { get; set; } = null!;

        public string? UserName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}

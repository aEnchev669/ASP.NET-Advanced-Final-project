using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheReader.Core.Models.User
{
	public class RoleViewModel
	{
		[Required]
		public string Id { get; set; } = string.Empty;

		[Required]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters long!")]

		public string RoleName { get; set; } = string.Empty;
	}
}

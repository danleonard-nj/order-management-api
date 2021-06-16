using Common.Models.Authentication.User.Abstractions;

namespace Services.DesertMusic.Api.Models.Authentication
{
		public class AuthenticationModel : IUserModel
		{
				public int UserId { get; set; }
				public string Username { get; set; }
				public string Email { get; set; }
				public string Password { get; set; }
				public string Salt { get; set; }
				public string Role { get; set; }
		}

		public class TokenResponseModel
		{
				public bool IsAuthenticated { get; set; }
				public string Token { get; set; }
				public string Error { get; set; }
		}
}

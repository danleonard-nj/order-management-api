using Common.Utilities.UserManagement.Models;
using Services.DesertMusic.Api.Components.AuthenticationComponent;
using Services.DesertMusic.Api.Models.Authentication;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components
{
		public interface IAuthenticationProvider
		{
				Task<TokenResponseModel> Authenticate(AuthenticationModel authenticationModel);
				Task<UserModel> CreateUser(UserModel model);
		}

		public class AuthenticationProvider : IAuthenticationProvider
		{
				public AuthenticationProvider(IAuthenticationComponent authenticationComponent)
				{
						_authenticationComponent = authenticationComponent;
				}

				public async Task<TokenResponseModel> Authenticate(AuthenticationModel authenticationModel)
				{
						var token = await _authenticationComponent.Authenticate(authenticationModel);

						return token;
				}

				public async Task<UserModel> CreateUser(UserModel model)
				{
						var user = await _authenticationComponent.CreateUser(model);

						return user;
				}

				private readonly IAuthenticationComponent _authenticationComponent;
		}
}

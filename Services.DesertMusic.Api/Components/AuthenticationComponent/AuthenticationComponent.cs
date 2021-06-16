using Common.Utilities.Helpers;
using Common.Utilities.UserManagement.Components;
using Common.Utilities.UserManagement.Models;
using Services.DesertMusic.Api.Models.Authentication;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components.AuthenticationComponent
{
		public interface IAuthenticationComponent
		{
				Task<TokenResponseModel> Authenticate(AuthenticationModel authenticationModel);
				Task<UserModel> CreateUser(UserModel model);
		}

		public class AuthenticationComponent : IAuthenticationComponent
		{
				public AuthenticationComponent(IUserManagementComponent userManagementComponent)
				{
						_userManagementComponent = userManagementComponent;
				}

				public async Task<TokenResponseModel> Authenticate(AuthenticationModel authenticationModel)
				{
						try
						{
								var token = await _userManagementComponent.AuthenticateUser(authenticationModel);

								var successful = new TokenResponseModel
								{
										IsAuthenticated = true,
										Token = token
								};

								return successful;
						}

						catch (Exception ex)
						{
								var failure = new TokenResponseModel
								{
										IsAuthenticated = false,
										Error = ex.Message
								};

								return failure;
						}
				}

				public async Task<UserModel> CreateUser(UserModel model)
				{
						var user = await _userManagementComponent.CreateUser(model);

						if (!user)
						{
								throw new AuthenticationException($"{GetType()}: {Caller.GetMethodName()}: Failed to create user.");
						}

						return model;
				}

				private readonly IUserManagementComponent _userManagementComponent;
		}
}

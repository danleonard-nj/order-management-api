/* Copyright (C) 2012, 2013 Dan Leonard
 * 
 * This is free software: you can redistribute it and/or modify it under 
 * the terms of the GNU General Public License as published by the Free 
 * Software Foundation, either version 3 of the License, or (at your option) 
 * any later version.
 * 
 * This software is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License 
 * for more details.
 */


using Common.Utilities.Authentication.Jwt;
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
				Task<TokenResponseModel> GetRefreshToken(string token);
		}

		public class AuthenticationComponent : IAuthenticationComponent
		{
				public AuthenticationComponent(IUserManagementComponent userManagementComponent,
						IJwtTokenUtility jwtTokenUtility)
				{
						_userManagementComponent = userManagementComponent ?? throw new ArgumentNullException(nameof(userManagementComponent));
						_jwtTokenUtility = jwtTokenUtility ?? throw new ArgumentNullException(nameof(jwtTokenUtility));
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

				public async Task<TokenResponseModel> GetRefreshToken(string token)
				{
						await Task.Yield();

						var refreshToken = _jwtTokenUtility.GetRefreshToken(token);

						var response = new TokenResponseModel
						{
								IsAuthenticated = true,
								Token = refreshToken
						};

						return response;
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
				private readonly IJwtTokenUtility _jwtTokenUtility;
		}
}

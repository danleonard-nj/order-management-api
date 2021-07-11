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


using Common.Models.UserManagement;
using Common.Utilities.Exceptions.Authentication;
using Common.Utilities.Helpers;
using Common.Utilities.Jwt;
using Common.Utilities.Jwt.Extensions;
using Microsoft.AspNetCore.Http;
using Services.DesertMusic.Api.Components.User;
using Services.DesertMusic.Api.Models.Authentication;
using System;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components.AuthenticationComponent
{
		public interface IAuthenticationComponent
		{
				Task<TokenResponseModel> Authenticate(UserModel user);
				Task<TokenResponseModel> Refresh(HttpContext context);
		}

		public class AuthenticationComponent : IAuthenticationComponent
		{
				public AuthenticationComponent(IUserComponent userComponent,
						IJwtTokenProvider jwtTokenProvider)
				{
						_userComponent = userComponent ?? throw new ArgumentNullException(nameof(userComponent));
						_jwtTokenProvider = jwtTokenProvider ?? throw new ArgumentNullException(nameof(jwtTokenProvider));
				}

				public async Task<TokenResponseModel> Authenticate(UserModel user)
				{
						try
						{
								var token = await _userComponent.AuthenticateUser(user);

								var response = new TokenResponseModel
								{
										IsAuthenticated = true,
										Token = token,
								};

								return response;
						}

						catch (Exception ex)
						{
								var response = new TokenResponseModel
								{
										IsAuthenticated = false,
										Error = ex.Message
								};

								return response;
						}
				}

				public async Task<TokenResponseModel> Refresh(HttpContext context)
				{
						try
						{
								var bearer = context.GetBearerToken();

								if (bearer == null)
								{
										throw new InvalidTokenException<AuthenticationComponent>(Caller.GetMethodName());
								}
								
								var payload = await _jwtTokenProvider.GetPayload(bearer);

								payload.Refresh(_jwtTokenProvider.TokenLifetime);

								var refreshToken = await _jwtTokenProvider.GetToken(payload);

								var response = new TokenResponseModel
								{
										IsAuthenticated = true,
										Token = refreshToken
								};

								return response;
						}

						catch (Exception ex)
						{
								var response = new TokenResponseModel
								{
										Error = ex.Message,
										IsAuthenticated = false
								};

								return response;
						}
				}

				private readonly IUserComponent _userComponent;
				private readonly IJwtTokenProvider _jwtTokenProvider;
		}
}

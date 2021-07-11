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
using Microsoft.AspNetCore.Http;
using Services.DesertMusic.Api.Components.AuthenticationComponent;
using Services.DesertMusic.Api.Models.Authentication;
using System;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components
{
		public interface IAuthenticationProvider
		{
				Task<TokenResponseModel> Authenticate(UserModel user);
				Task<TokenResponseModel> Refresh(HttpContext context);
		}

		public class AuthenticationProvider : IAuthenticationProvider
		{
				public AuthenticationProvider(IAuthenticationComponent authenticationComponent)
				{
						_authenticationComponent = authenticationComponent ?? throw new ArgumentNullException(nameof(authenticationComponent));
				}

				public async Task<TokenResponseModel> Authenticate(UserModel user)
				{
						var response = await _authenticationComponent.Authenticate(user);

						return response;
				}

				public async Task<TokenResponseModel> Refresh(HttpContext context)
				{
						var response = await _authenticationComponent.Refresh(context);

						return response;
				}

				private readonly IAuthenticationComponent _authenticationComponent;
		}
}

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


using Common.Utilities.Authentication.Attributes;
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

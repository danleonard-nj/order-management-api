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
using Common.Utilities.AspNetCore.Response.Extensions;
using Common.Utilities.Jwt.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;
using Services.DesertMusic.Api.Components;
using System;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Controllers
{
		[Route("api/[controller]")]
		[ApiController]
		public class AuthenticationController : ControllerBase
		{
				public AuthenticationController(IAuthenticationProvider authenticationProvider)
				{
						_authenticationProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));
				}
				
				[HttpPost("User")]
				[BypassAuthentication]
				public async Task<IActionResult> AuthenticateUser(UserModel model)
				{
						var token = await _authenticationProvider.Authenticate(model);

						return token.ToResponse();
				}

				[HttpGet("Refresh")]
				public async Task<IActionResult> RefreshToken()
				{
						var result = await _authenticationProvider.Refresh(HttpContext);

						return result.ToResponse();
				}

				private readonly IAuthenticationProvider _authenticationProvider;
		}
}

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


using Common.Utilities.AspNetCore.Response.Extensions;
using Common.Utilities.UserManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Services.DesertMusic.Api.Components;
using System;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Controllers
{
		[Route("api/[controller]")]
		[ApiController]
		public class UserController : ControllerBase
		{
				public UserController(IAuthenticationProvider authenticationProvider)
				{
						_authenticationProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));
				}

				[HttpPost("User/Create")]
				public async Task<IActionResult> CreateUser(UserModel model)
				{
						var result = await _authenticationProvider.CreateUser(model);

						return result.ToResponse();
				}

				private readonly IAuthenticationProvider _authenticationProvider;
		}
}

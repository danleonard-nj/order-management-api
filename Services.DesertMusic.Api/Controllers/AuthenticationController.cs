using Common.Utilities.AspNetCore.Response.Extensions;
using Common.Utilities.Authentication.Attributes;
using Common.Utilities.UserManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Services.DesertMusic.Api.Components;
using Services.DesertMusic.Api.Models.Authentication;
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
				
				[HttpPost("User/Authenticate")]
				[BypassAuthentication]
				public async Task<IActionResult> AuthenticateUser(AuthenticationModel model)
				{
						var token = await _authenticationProvider.Authenticate(model);

						return token.ToResponse();
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

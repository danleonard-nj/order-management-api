using Common.Utilities.AspNetCore.Response.Extensions;
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
				public UserController(IUserProvider userProvider)
				{
						_userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
				}

				[HttpGet("All")]
				public async Task<IActionResult> GetUsers()
				{
						var response = await _userProvider.GetUsers();

						return response.ToResponse();
				}

				private readonly IUserProvider _userProvider;
		}
}

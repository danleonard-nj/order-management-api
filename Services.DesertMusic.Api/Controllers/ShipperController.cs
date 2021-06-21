using Common.Utilities.AspNetCore.Response.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DesertMusic.Api.Components;
using Services.DesertMusic.Api.Models.Shipper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Controllers
{
		[Route("api/[controller]")]
		[ApiController]
		public class ShipperController : ControllerBase
		{
				public ShipperController(IShipperProvider shipperProvider)
				{
						_shipperProvider = shipperProvider ?? throw new ArgumentNullException(nameof(shipperProvider));
				}

				[HttpPost]
				public async Task<IActionResult> CreateShipper(ShipperModel model)
				{
						var result = await _shipperProvider.CreateShipper(model);

						return true.ToResponse();
				}

				[HttpGet("Default")]
				public async Task<IActionResult> GetDefaultShipper()
				{
						var result = await _shipperProvider.GetDefaultShipper();

						return result.ToResponse();
				}

				[HttpGet("{shipperId}")]
				public async Task<IActionResult> GetShipper(int shipperId)
				{
						var result = await _shipperProvider.GetShipper(shipperId);

						return result.ToResponse();
				}

				[HttpGet("All")]
				public async Task<IActionResult> GetShippers()
				{
						var result = await _shipperProvider.GetShippers();

						return result.ToResponse();
				}

				[HttpPut]
				public async Task<IActionResult> UpdateShipper(ShipperModel model)
				{
						var result = await _shipperProvider.UpdateShipper(model);

						return true.ToResponse();
				}

				[HttpDelete("{shipperId}")]
				public async Task<IActionResult> DeleteShipper(int shipperId)
				{
						var result = await _shipperProvider.DeleteShipper(shipperId);

						return result.ToResponse();
				}

				[HttpPut("{shipperId}/Default")]
				public async Task<IActionResult> UpdateDefaultShipper(int shipperId)
				{
						var result = await _shipperProvider.UpdateDefaultShipper(shipperId);

						return result.ToResponse();
				}

				private readonly IShipperProvider _shipperProvider;
		}

}

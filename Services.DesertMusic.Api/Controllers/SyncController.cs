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
using Microsoft.AspNetCore.Mvc;
using Services.DesertMusic.Api.Components.ReverbSyncComponent;
using Services.DesertMusic.Api.Components.ReverbSyncComponent.Data;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Controllers
{
		[ApiController]
		[Route("api/[controller]")]
		public class SyncController : Controller
		{
				public SyncController(IReverbSyncComponent reverbSyncComponent,
						IReverbSyncRepository reverbSyncRepository)
				{
						_reverbSyncComponent = reverbSyncComponent;
						_reverbSyncRepository = reverbSyncRepository;
				}

				[HttpGet("SyncOrders")]
				[BypassAuthentication]
				public async Task<IActionResult> GetOrders()
				{
						var result = await _reverbSyncComponent.SyncOrders();

						return new ObjectResult(result);
				}

				

				private readonly IReverbSyncComponent _reverbSyncComponent;
				private readonly IReverbSyncRepository _reverbSyncRepository;
		}
}

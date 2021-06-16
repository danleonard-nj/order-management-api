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

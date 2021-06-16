using Flurl.Http;
using Flurl.Http.Configuration;
using Services.DesertMusic.Api.Clients.Reverb.Models.Orders;
using System;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Clients.Reverb
{
		public interface IReverbClient
		{
				Task<OrdersModel> GetOrders(int pageNumber = 1);
		}

		public class ReverbClient : IReverbClient
		{
				public ReverbClient(IFlurlClientFactory flurlClientFactory,
						ReverbClientSettings settings)
				{
						_settings = settings ?? throw new ArgumentNullException(nameof(settings));

						if (flurlClientFactory == null)
						{
								throw new ArgumentNullException(nameof(flurlClientFactory));
						}

						_flurlClient = flurlClientFactory.Get(new Flurl.Url(settings.BaseUrl));
				}

				public async Task<OrdersModel> GetOrders(int pageNumber = 1)
				{
						var response = await _flurlClient
								.Request(_settings.Orders)
								.WithOAuthBearerToken(_settings.Token)
								.SetQueryParam("page", pageNumber)
								.GetAsync()
								.ReceiveJson<OrdersModel>();

						return response;
				}

				private readonly IFlurlClient _flurlClient;
				private readonly ReverbClientSettings _settings;
		}
}

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
								.WithOAuthBearerToken(_settings.ReverbBearerToken)
								.SetQueryParam("page", pageNumber)
								.GetAsync()
								.ReceiveJson<OrdersModel>();

						return response;
				}

				private readonly IFlurlClient _flurlClient;
				private readonly ReverbClientSettings _settings;
		}
}

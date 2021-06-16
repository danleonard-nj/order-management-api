using Common.Utilities.Extensions;
using Common.Utilities.Helpers;
using Microsoft.Extensions.Logging;
using Services.DesertMusic.Api.Clients.Reverb;
using Services.DesertMusic.Api.Clients.Reverb.Models.Orders;
using Services.DesertMusic.Api.Components.ReverbSyncComponent.Data;
using Services.DesertMusic.Api.Components.ReverbSyncComponent.Domain;
using Services.DesertMusic.Api.Components.ReverbSyncComponent.Extensions;
using Services.DesertMusic.Api.Utilities.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components.ReverbSyncComponent
{
		public interface IReverbSyncComponent
		{
				Task<bool> SyncOrders();
		}

		public class ReverbSyncComponent : IReverbSyncComponent
		{
				public ReverbSyncComponent(IReverbClient reverbClient,
						IReverbSyncRepository reverbSyncRepository,
						ILoggerFactory loggerFactory)
				{
						if (loggerFactory == null)
						{
								throw new ArgumentNullException(nameof(loggerFactory));
						}

						_logger = loggerFactory.CreateLogger(typeof(ReverbSyncComponent));

						_reverbClient = reverbClient ?? throw new ArgumentNullException(nameof(reverbClient));
						_reverbSyncRepository = reverbSyncRepository ?? throw new ArgumentNullException(nameof(reverbSyncRepository));
				}

				public async Task<bool> SyncOrders()
				{
						var orders = await GetSyncOrders();

						await InsertSyncOrders(orders);

						return true;
				}

				private async Task<IEnumerable<OrderModel>> GetSyncOrders()
				{
						_logger.Log(LogLevel.Information, $"{GetType()}: {Caller.GetMethodName()}: Fetching orders to sync.");

						var totalPages = await GetSyncOrderCount();

						var results = await Enumerable.Range(1, totalPages)
								.RunConcurrent(page => _reverbClient.GetOrders(page), 16);

						var orders = results
								.SelectMany(x => x.Orders);

						_logger.Log(LogLevel.Information, $"{GetType()}: {Caller.GetMethodName()}: {orders.Count()} orders fetched to sync.");

						return orders;
				}

				private async Task InsertSyncOrders(IEnumerable<OrderModel> orders)
				{
						var syncOrders = orders
								.Select(order => order.ToSyncOrder());

						await _reverbSyncRepository.UpsertSyncOrders(syncOrders);

						//foreach (var order in orders)
						//{
						//		_logger.Log(LogLevel.Information, $"{GetType()}: {Caller.GetMethodName()}: OrderNumber {order.OrderNumber}: Inserting sync order.");

						//		_logger.Log(LogLevel.Information, $"{GetType()}: {Caller.GetMethodName()}: OrderNumber {order.OrderNumber}: Converting order to domain");
						//		_logger.Log(LogLevel.Information, $"{GetType()}: {Caller.GetMethodName()}: OrderNumber {order.OrderNumber}: Order: {order.SerializeObject()}");

						//		var syncOrder = order.ToSyncOrder();

						//		_logger.Log(LogLevel.Information, $"{GetType()}: {Caller.GetMethodName()}: OrderNumber {order.OrderNumber}: {syncOrder.SerializeObject()}");

						//		await _reverbSyncRepository.UpsertSyncOrders(syncOrder);

						//		_logger.Log(LogLevel.Information, $"{GetType()}: {Caller.GetMethodName()}: OrderNumber {order.OrderNumber}: Insert successful.");
						//}
				}

				private async Task<int> GetSyncOrderCount()
				{
						var response = await _reverbClient.GetOrders();

						return response.TotalPages;
				}

				//private async Task<OrderHash> GetInsertOrders()
				//{
				//}
				
				//private async Task<OrderHash> GetUpdateOrders()
				//{

				//}

				private readonly IReverbSyncRepository _reverbSyncRepository;
				private readonly IReverbClient _reverbClient;
				private readonly ILogger _logger;
		}
}

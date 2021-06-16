using Common.Utilities.Helpers;
using Dapper;
using Microsoft.Extensions.Logging;
using Services.DesertMusic.Api.Components.ReverbSyncComponent.Domain;
using Services.DesertMusic.Api.Components.ReverbSyncComponent.Extensions;
using Services.DesertMusic.Api.Utilities.Threading;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components.ReverbSyncComponent.Data
{
		public interface IReverbSyncRepository
		{
				Task<bool> UpsertSyncOrders(IEnumerable<SyncOrder> orders);
		}

		public class ReverbSyncRepository : IReverbSyncRepository
		{
				public ReverbSyncRepository(ILoggerFactory loggerFactory,
						ReverbSyncRepositorySettings settings)
				{
						_settings = settings ?? throw new ArgumentNullException(nameof(settings));	

						if (loggerFactory == null)
						{
								throw new ArgumentNullException(nameof(loggerFactory));
						}

						_logger = loggerFactory.CreateLogger(typeof(ReverbSyncRepository));
				}

				public async Task<bool> UpsertSyncOrders(IEnumerable<SyncOrder> orders)
				{
						//await orders.RunConcurrent(order => UpsertSyncOrder(order));

						await orders.RunConcurrent(order => UpsertSyncOrder(order), 20);

						return true;
				}

				private async Task<bool> UpsertSyncOrder(SyncOrder order)
				{
						_logger.Log(LogLevel.Information, $"{GetType()}: {Caller.GetMethodName()}: Order #: {order.OrderNumber}: Upsert routine started.");

						var _params = order.ToSqlParams();

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								await connection.ExecuteAsync("dbo.spOrderSyncUpsert", _params, commandType: CommandType.StoredProcedure);
						}

						_logger.Log(LogLevel.Information, $"{GetType()}: {Caller.GetMethodName()}: Order #: {order.OrderNumber}: Upsert successful.");

						return true;
				}



				private readonly ReverbSyncRepositorySettings _settings;
				private readonly ILogger _logger;

		}
}

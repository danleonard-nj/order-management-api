using Common.Utilities.DependencyInjection;
using Common.Utilities.DependencyInjection.Exports.Types;
using Common.Utilities.DependencyInjection.Exports.Types.Abstractions;
using Flurl.Http.Configuration;
using Services.DesertMusic.Api.Clients.Reverb;
using Services.DesertMusic.Api.Components;
using Services.DesertMusic.Api.Components.AuthenticationComponent;
using Services.DesertMusic.Api.Components.ReverbSyncComponent;
using Services.DesertMusic.Api.Components.ReverbSyncComponent.Data;
using Services.DesertMusic.Api.Components.ShipperComponent;
using Services.DesertMusic.Api.Components.ShipperComponent.Data;
using System.Collections.Generic;

namespace Services.DesertMusic.Api.Configuration
{
		public class DependencyExports : IDependencyExport
		{
				public IEnumerable<IServiceExport> GetServiceExports()
				{
						var services = new List<IServiceExport>
						{
								new ServiceExport<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>(RegistrationType.Singleton),

								// Clients

								new ServiceExport<IReverbClient, ReverbClient>(),

								// Data

								new ServiceExport<IReverbSyncRepository, ReverbSyncRepository>(),
								new ServiceExport<IShipperRepository, ShipperRepository>(),

								// Components

								new ServiceExport<IReverbSyncComponent, ReverbSyncComponent>(),
								new ServiceExport<IAuthenticationComponent, AuthenticationComponent>(),
								new ServiceExport<IShipperComponent, ShipperComponent>(),

								// Providers

								new ServiceExport<IAuthenticationProvider, AuthenticationProvider>(),
								new ServiceExport<IShipperProvider, ShipperProvider>()
						};

						return services;
				}

				public IEnumerable<ISettingsExport> GetSettingsExports()
				{
						var settings = new List<ISettingsExport>
						{
								new SettingsExport<ReverbClientSettings>(),
								new SettingsExport<ReverbSyncRepositorySettings>(),
								new SettingsExport<ShipperRepositorySettings>()
						};

						return settings;
				}
		}
}

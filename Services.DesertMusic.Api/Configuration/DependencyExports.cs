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
using Services.DesertMusic.Api.Components.User;
using Services.DesertMusic.Api.Components.User.Data;
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

								new ServiceExport<IReverbClient, ReverbClient>(RegistrationType.Scoped),

								// Data

								new ServiceExport<IReverbSyncRepository, ReverbSyncRepository>(RegistrationType.Scoped),
								new ServiceExport<IShipperRepository, ShipperRepository>(RegistrationType.Scoped),
								new ServiceExport<IUserRepository, UserRepository>(RegistrationType.Scoped),

								// Components

								new ServiceExport<IReverbSyncComponent, ReverbSyncComponent>(RegistrationType.Scoped),
								new ServiceExport<IAuthenticationComponent, AuthenticationComponent>(RegistrationType.Scoped),
								new ServiceExport<IUserComponent, UserComponent>(RegistrationType.Scoped),
								new ServiceExport<IShipperComponent, ShipperComponent>(RegistrationType.Scoped),

								// Providers

								new ServiceExport<IAuthenticationProvider, AuthenticationProvider>(RegistrationType.Scoped),
								new ServiceExport<IShipperProvider, ShipperProvider>(RegistrationType.Scoped),
								new ServiceExport<IUserProvider, UserProvider>(RegistrationType.Scoped)
						};

						return services;
				}

				public IEnumerable<ISettingsExport> GetSettingsExports()
				{
						var settings = new List<ISettingsExport>
						{
								new SettingsExport<ReverbClientSettings>(),
								new SettingsExport<ReverbSyncRepositorySettings>(),
								new SettingsExport<ShipperRepositorySettings>(),
								new SettingsExport<UserRepositorySettings>()
						};

						return settings;
				}
		}
}

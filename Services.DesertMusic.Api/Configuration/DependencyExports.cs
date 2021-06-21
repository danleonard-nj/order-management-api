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
using Services.DesertMusic.Api.Components;
using Services.DesertMusic.Api.Components.AuthenticationComponent;
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

								// Data

								new ServiceExport<IShipperRepository, ShipperRepository>(),

								// Components

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
								new SettingsExport<ShipperRepositorySettings>()
						};

						return settings;
				}
		}
}

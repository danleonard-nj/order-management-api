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


using Services.DesertMusic.Api.Components.ShipperComponent;
using Services.DesertMusic.Api.Models.Shipper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components
{
		public interface IShipperProvider
		{
				Task<bool> CreateShipper(ShipperModel model);
				Task<bool> DeleteShipper(int shipperId);
				Task<ShipperModel> GetDefaultShipper();
				Task<ShipperModel> GetShipper(int shipperId);
				Task<IEnumerable<ShipperModel>> GetShippers();
				Task<bool> UpdateDefaultShipper(int shipperId);
				Task<bool> UpdateShipper(ShipperModel model);
		}

		public class ShipperProvider : IShipperProvider
		{
				public ShipperProvider(IShipperComponent shipperComponent)
				{
						_shipperComponent = shipperComponent ?? throw new ArgumentNullException(nameof(shipperComponent));
				}

				public async Task<bool> CreateShipper(ShipperModel model)
				{
						var result = await _shipperComponent.CreateShipper(model);

						return result;
				}

				public async Task<ShipperModel> GetDefaultShipper()
				{
						var result = await _shipperComponent.GetDefaultShipper();

						return result;
				}

				public async Task<ShipperModel> GetShipper(int shipperId)
				{
						var result = await _shipperComponent.GetShipper(shipperId);

						return result;
				}

				public async Task<IEnumerable<ShipperModel>> GetShippers()
				{
						var result = await _shipperComponent.GetShippers();

						return result;
				}

				public async Task<bool> UpdateShipper(ShipperModel model)
				{
						var result = await _shipperComponent.UpdateShipper(model);

						return result;
				}

				public async Task<bool> DeleteShipper(int shipperId)
				{
						var result = await _shipperComponent.DeleteShipper(shipperId);

						return result;
				}

				public async Task<bool> UpdateDefaultShipper(int shipperId)
				{
						var result = await _shipperComponent.UpdateDefaultShipper(shipperId);

						return result;
				}

				private readonly IShipperComponent _shipperComponent;
		}
}

using Services.DesertMusic.Api.Components.ShipperComponent;
using Services.DesertMusic.Api.Models.Shipper;
using System;
using System.Collections.Generic;
using System.Linq;
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

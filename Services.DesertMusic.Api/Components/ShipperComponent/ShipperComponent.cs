using Services.DesertMusic.Api.Components.ShipperComponent.Data;
using Services.DesertMusic.Api.Components.ShipperComponent.Extensions;
using Services.DesertMusic.Api.Models.Shipper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components.ShipperComponent
{
		public interface IShipperComponent
		{
				Task<bool> CreateShipper(ShipperModel model);
				Task<bool> DeleteShipper(int shipperId);
				Task<ShipperModel> GetDefaultShipper();
				Task<ShipperModel> GetShipper(int shipperId, bool isActive = true);
				Task<IEnumerable<ShipperModel>> GetShippers(bool isActive = true);
				Task<bool> UpdateShipper(ShipperModel model);
		}

		public class ShipperComponent : IShipperComponent
		{
				public ShipperComponent(IShipperRepository shipperRepository)
				{

						_shipperRepository = shipperRepository ?? throw new ArgumentNullException(nameof(shipperRepository));
				}

				public async Task<ShipperModel> GetShipper(int shipperId, bool isActive = true)
				{
						var shipper = await _shipperRepository.GetShipper(shipperId);

						var model = shipper?.ToModel();

						if (isActive)
						{
								return model.IsActive ? model : default;
						}

						return model;
				}

				public async Task<IEnumerable<ShipperModel>> GetShippers(bool isActive = true)
				{
						var shippers = await _shipperRepository.GetShippers();

						var models = shippers
								.Select(x => x.ToModel());

						if (isActive)
						{
								var activeShippers = models
										.Where(x => x.IsActive == true);

								return activeShippers;
						}

						return models;
				}

				public async Task<ShipperModel> GetDefaultShipper()
				{
						var shipper = await _shipperRepository.GetDefaultShipper();

						var model = shipper?.ToModel();

						return model;
				}

				public async Task<bool> CreateShipper(ShipperModel model)
				{
						var domain = model.ToDomain();

						await _shipperRepository.InsertShipper(domain);

						return true;
				}

				public async Task<bool> UpdateShipper(ShipperModel model)
				{
						var domain = model.ToDomain();

						await _shipperRepository.UpdateShipper(domain);

						return true;
				}

				public async Task<bool> DeleteShipper(int shipperId)
				{
						await _shipperRepository.DeleteShipper(shipperId);

						return true;
				}

				private readonly IShipperRepository _shipperRepository;
		}
}

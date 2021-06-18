using Services.DesertMusic.Api.Components.ShipperComponent.Domain;
using Services.DesertMusic.Api.Models.Shipper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components.ShipperComponent.Extensions
{
		public static class ShipperComponentExtensions
		{
				public static ShipperModel ToModel(this Shipper shipper)
				{
						var model = new ShipperModel
						{
								ShipperId = shipper.ShipperId,
								IsDefault = shipper.IsDefault,
								CompanyName = shipper.CompanyName,
								FirstName = shipper.FirstName,
								LastName = shipper.LastName,
								StreetAddress1 = shipper.StreetAddress1,
								StreetAddress2 = shipper.StreetAddress2,
								City = shipper.City,
								StateCode = shipper.StateCode,
								ZipCode = shipper.ZipCode,
								PhoneNumber = shipper.PhoneNumber,
								CountryCode = shipper.CountryCode,
								IsActive = shipper.IsActive
						};

						return model;
				}

				public static Shipper ToDomain(this ShipperModel model)
				{
						var shipper = new Shipper
						{
								ShipperId = model.ShipperId,
								IsDefault = model.IsDefault,
								CompanyName = model.CompanyName,
								FirstName = model.FirstName,
								LastName = model.LastName,
								StreetAddress1 = model.StreetAddress1,
								StreetAddress2 = model.StreetAddress2,
								City = model.City,
								StateCode = model.StateCode,
								ZipCode = model.ZipCode,
								PhoneNumber = model.PhoneNumber,
								CountryCode = model.CountryCode,
								IsActive = model.IsActive
						};

						return shipper;
				}
		}
}

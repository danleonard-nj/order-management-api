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


using Services.DesertMusic.Api.Components.ShipperComponent.Domain;
using Services.DesertMusic.Api.Models.Shipper;

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

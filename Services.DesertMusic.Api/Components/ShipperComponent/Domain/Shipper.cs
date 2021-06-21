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


using System;

namespace Services.DesertMusic.Api.Components.ShipperComponent.Domain
{
		public class Shipper
		{
				public int ShipperId { get; set; }
				public bool IsDefault { get; set; }
				public bool IsActive { get; set; }
				public string CompanyName { get; set; }
				public string FirstName { get; set; }
				public string LastName { get; set; }
				public string StreetAddress1 { get; set; }
				public string StreetAddress2 { get; set; }
				public string City { get; set; }
				public string StateCode { get; set; }
				public string ZipCode { get; set; }
				public string CountryCode { get; set; }
				public string PhoneNumber { get; set; }
				public DateTime CreatedDate { get; set; }
		}
}

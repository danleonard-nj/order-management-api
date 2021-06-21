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


using Newtonsoft.Json;

namespace Services.DesertMusic.Api.Clients.Reverb.Models.Orders
{
		public class OrderAddressModel
		{
				[JsonProperty(PropertyName = "region")]
				public string Region { get; set; }

				[JsonProperty(PropertyName = "locality")]
				public string Locality { get; set; }

				[JsonProperty(PropertyName = "country_code")]
				public string CountryCode { get; set; }

				[JsonProperty(PropertyName = "display_location")]
				public string DisplayLocation { get; set; }

				[JsonProperty(PropertyName = "id")]
				public string Id { get; set; }

				[JsonProperty(PropertyName = "primary")]
				public bool Primary { get; set; }

				[JsonProperty(PropertyName = "name")]
				public string Name { get; set; }

				[JsonProperty(PropertyName = "street_address")]
				public string StreetAddress { get; set; }

				[JsonProperty(PropertyName = "extended_address")]
				public string ExtendedAddress { get; set; }

				[JsonProperty(PropertyName = "postal_code")]
				public string PostalCode { get; set; }

				[JsonProperty(PropertyName = "phone")]
				public string Phone { get; set; }

				[JsonProperty(PropertyName = "unformatted_phone")]
				public string UnformattedPhone { get; set; }

				[JsonProperty(PropertyName = "complete_shipping_address")]
				public bool CompleteShippingAddress { get; set; }
		}
}

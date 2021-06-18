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

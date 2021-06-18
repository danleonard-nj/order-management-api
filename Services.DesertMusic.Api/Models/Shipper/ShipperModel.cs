using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Models.Shipper
{
		public class ShipperModel
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
				public string PhoneNumber { get; set; }
				public string CountryCode { get; set; }
		}
}

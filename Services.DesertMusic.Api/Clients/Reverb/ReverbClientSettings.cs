using Common.Utilities.Configuration.AzureKeyVault.Attributes;

namespace Services.DesertMusic.Api.Clients.Reverb
{
		public class ReverbClientSettings
		{
				public string BaseUrl { get; set; }

				[KeyVaultSecret]
				public string ReverbBearerToken { get; set; }
				public string Orders { get; set; }
		}
}

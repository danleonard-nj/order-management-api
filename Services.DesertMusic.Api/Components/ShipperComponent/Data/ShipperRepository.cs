using Common.Utilities.Helpers;
using Dapper;
using Services.DesertMusic.Api.Components.ShipperComponent.Domain;
using Services.DesertMusic.Api.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components.ShipperComponent.Data
{
		public interface IShipperRepository
		{
				Task DeleteShipper(int shipperId);
				Task<Shipper> GetDefaultShipper();
				Task<Shipper> GetShipper(int shipperId);
				Task<IEnumerable<Shipper>> GetShippers();
				Task InsertShipper(Shipper shipper);
				Task UpdateShipper(Shipper shipper);
		}

		public class ShipperRepository : IShipperRepository
		{
				public ShipperRepository(ShipperRepositorySettings settings)
				{
						_settings = settings ?? throw new ArgumentNullException(nameof(settings));
				}

				public async Task InsertShipper(Shipper shipper)
				{
						var sql = @"
								INSERT dbo.Shipper (
                    IsDefault,
										IsActive,
                    CompanyName,
                    FirstName,
                    LastName,
                    StreetAddress1,
                    StreetAddress2,
                    City,
                    StateCode,
                    ZipCode,
                    CountryCode,
										PhoneNumber,
                    CreatedDate)
                VALUES (
                    @IsDefault,
										1,
                    @CompanyName,
                    @FirstName,
                    @LastName,
                    @StreetAddress1,
                    @StreetAddress2,
                    @City,
                    @StateCode,
                    @ZipCode,
                    @CountryCode,
										@PhoneNumber,
                    GETDATE())";

						if (shipper.IsDefault)
						{
								await VerifyDefaultShipper();
						}

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								var result = await connection.ExecuteAsync(sql, shipper);
						}
				}

				public async Task UpdateShipper(Shipper shipper)
				{
						var sql = @"
								UPDATE dbo.Shipper
                SET IsDefault = @IsDefault,
                    CompanyName = @CompanyName,
                    FirstName = @FirstName,
                    LastName = @LastName,
                    StreetAddress1 = @StreetAddress1,
                    StreetAddress2 = @StreetAddress2,
                    City = @City,
                    StateCode = @StateCode, 
                    ZipCode = @ZipCode,
                    CountryCode = @CountryCode,
										PhoneNumber = @PhoneNumber
                WHERE ShipperId = @ShipperId";

						if (shipper.IsDefault)
						{
								await VerifyDefaultShipper();
						}

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								var result = await connection.ExecuteAsync(sql, shipper);
						}
				}

				public async Task<Shipper> GetShipper(int shipperId)
				{
						var sql = @"
								SELECT
										ShipperId,
										IsDefault,
										IsActive,
										CompanyName,
										FirstName,
										LastName,
										StreetAddress1,
										StreetAddress2,
										City,
										StateCode,
										ZipCode,
										CountryCode,
										PhoneNumber,
										CreatedDate
								FROM dbo.Shipper
								WHERE ShipperId = @ShipperId";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								var result = await connection.QueryFirstOrDefaultAsync<Shipper>(sql, new { shipperId });

								return result;
						}
				}

				public async Task<IEnumerable<Shipper>> GetShippers()
				{
						var sql = @"
								SELECT
										ShipperId,
										IsDefault,
										IsActive,
										CompanyName,
										FirstName,
										LastName,
										StreetAddress1,
										StreetAddress2,
										City,
										StateCode,
										ZipCode,
										CountryCode,
										PhoneNumber,
										CreatedDate
								FROM dbo.Shipper";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								var result = await connection.QueryAsync<Shipper>(sql);

								return result;
						}
				}

				public async Task<Shipper> GetDefaultShipper()
				{
						var sql = @"
								SELECT
										ShipperId,
										IsDefault,
										IsActive,
										CompanyName,
										FirstName,
										LastName,
										StreetAddress1,
										StreetAddress2,
										City,
										StateCode,
										ZipCode,
										CountryCode,
										PhoneNumber,
										CreatedDate
								FROM dbo.Shipper
								WHERE IsDefault = 1";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								var result = await connection.QueryFirstOrDefaultAsync<Shipper>(sql);

								return result;
						}
				}

				public async Task DeleteShipper(int shipperId)
				{
						var sql = @"
								UPDATE dbo.Shipper
								SET IsActive = 0
								WHERE ShipperId = @ShipperId";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								await connection.ExecuteAsync(sql, new { shipperId });
						}
				}

				private async Task VerifyDefaultShipper()
				{
						var sql = @"
								SELECT ShipperId
								FROM dbo.Shipper
								WHERE IsDefault = 1";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								var results = await connection.QueryAsync<int>(sql);

								if (results.Any())
								{
										throw new Exception($"{GetType()}: {Caller.GetMethodName()}: Default shipper is already configured.");
								}
						}
				}

				private readonly ShipperRepositorySettings _settings;
		}
}

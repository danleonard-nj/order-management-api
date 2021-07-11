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


using Common.Models.UserManagement;
using Common.Models.UserManagement.Abstractions;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components.User.Data
{
		public interface IUserRepository
		{
				Task DeleteUser(int userId);
				Task<UserModel> GetUserByUsername(string username);
				Task<IEnumerable<IUserModel>> GetUsers();
				Task InsertUser(IUserModel userModel);
				Task<IUserModel> UpdateUser(IUserModel userModel);
		}

		public class UserRepository : IUserRepository
		{
				public UserRepository(UserRepositorySettings settings)
				{
						_settings = settings ?? throw new ArgumentNullException(nameof(settings));
				}

				public async Task InsertUser(IUserModel userModel)
				{
						var sql = @"
								INSERT [dbo].[User] (
										Username,
										Email,
										Password,
										Salt,
										CreatedDate )
								VALUES (
										@Username,
										@Email,
										@Password,
										@Salt,
										GETDATE())";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								await connection.ExecuteAsync(sql, userModel);
						}
				}

				public async Task<UserModel> GetUserByUsername(string username)
				{
						var sql = @"
								SELECT UserId,
										Username,
										Email,
										Role,
										Password,
										Salt
								FROM [dbo].[User]
								WHERE Username = @Username";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								var user = await connection.QueryFirstOrDefaultAsync<UserModel>(sql, new { username });

								return user;
						}
				}

				public async Task DeleteUser(int userId)
				{
						var sql = @"
								DELETE FROM [dbo].[User]
								WHERE UserId = @UserId";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								await connection.ExecuteAsync(sql, new { userId });
						}
				}

				public async Task<IUserModel> UpdateUser(IUserModel userModel)
				{
						var sql = @"
								UPDATE [dbo].[User]
								SET Username = @Username,
										Email = @Email,
										Role = @Role,
										Password = @Password,
										Salt = @Salt
								WHERE UserId = @UserId";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								await connection.ExecuteAsync(sql, userModel);

								return userModel;
						}
				}

				public async Task<IEnumerable<IUserModel>> GetUsers()
				{
						var sql = @"
								SELECT
										UserId,
										Username,
										Email,
										Role,
										CreatedDate
								FROM [dbo].[User]";

						using (var connection = new SqlConnection(_settings.SqlConnectionString))
						{
								var users = await connection.QueryAsync<UserModel>(sql);

								return users;
						}
				}

				private readonly UserRepositorySettings _settings;
		}

}

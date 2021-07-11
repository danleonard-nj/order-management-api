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


using Common.Models.UserManagement.Abstractions;
using Common.Utilities.Cryptography;
using Common.Utilities.Exceptions.Authentication.Base;
using Common.Utilities.Exceptions.UserManagement;
using Common.Utilities.Extensions.Base;
using Common.Utilities.Helpers;
using Common.Utilities.Jwt;
using Common.Utilities.UserManagement.Abstractions;
using Services.DesertMusic.Api.Components.User.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DesertMusic.Api.Components.User
{
		public interface IUserComponent
		{
				Task<string> AuthenticateUser(IUserModel user);
				Task<bool> CreateUser(IUserModel user);
				Task<bool> DeleteUser(int userId);
				Task<IUserModel> GetUser(string username);
				Task<IEnumerable<IUserModel>> GetUsers();
				Task<IUserModel> UpdateUser(IUserModel user);
		}

		public class UserComponent : UserManagementBase, IUserComponent
		{
				public UserComponent(IJwtTokenProvider jwtTokenProvider,
						ICryptoUtility cryptoUtility,
						IUserRepository repository)
						: base(jwtTokenProvider, cryptoUtility)
				{
						_repository = repository ?? throw new ArgumentNullException(nameof(repository));
				}

				public override async Task<string> AuthenticateUser(IUserModel user)
				{
						var dbUser = await _repository.GetUserByUsername(user.Username);

						var isValid = await VerifyHashedPassword(dbUser.Password, user.Password, dbUser.Salt);

						if (!isValid)
						{
								throw new IncorrectPasswordException<UserComponent>(Caller.GetMethodName());
						}

						try
						{
								var token = await GetIdentityToken(user);

								return token;
						}

						catch (Exception ex)
						{
								throw new AuthenticationException<UserComponent>(
										Caller.GetMethodName(),
										$"Failed to generate token for user {user.Username}: {ex.Message}");
						}
				}

				public override async Task<bool> CreateUser(IUserModel user)
				{
						try
						{
								await _repository.InsertUser(user);

								return true;
						}

						catch (Exception ex)
						{
								throw new CommonException(
										Caller.GetMethodName(),
										$"Failed to insert user: {ex.Message}",
										typeof(UserComponent));
						}
				}

				public override async Task<bool> DeleteUser(int userId)
				{
						try
						{
								await _repository.DeleteUser(userId);

								return true;
						}

						catch (Exception ex)
						{
								throw new CommonException(
										Caller.GetMethodName(),
										$"Failed to delete user: {ex.Message}",
										typeof(UserComponent));
						}
				}

				public override async Task<IUserModel> GetUser(string username)
				{
						try
						{
								var user = await _repository.GetUserByUsername(username);

								return user;
						}

						catch (Exception ex)
						{
								throw new CommonException(
										Caller.GetMethodName(),
										$"Failed to fetch user: {ex.Message}",
										typeof(UserComponent));
						}
				}

				public override async Task<IUserModel> UpdateUser(IUserModel user)
				{
						try
						{
								var updateUser = await _repository.UpdateUser(user);

								return updateUser;
						}

						catch (Exception ex)
						{
								throw new CommonException(
										Caller.GetMethodName(),
										$"Failed to update user: {ex.Message}",
										typeof(UserComponent));
						}
				}

				public async Task<IEnumerable<IUserModel>> GetUsers()
				{
						try
						{
								var users = await _repository.GetUsers();

								return users;
						}

						catch (Exception ex)
						{
								throw new CommonException(
										Caller.GetMethodName(),
										$"Failed to fetch user list: {ex.Message}",
										typeof(UserComponent));
						}
				}

				private readonly IUserRepository _repository;
		}
}

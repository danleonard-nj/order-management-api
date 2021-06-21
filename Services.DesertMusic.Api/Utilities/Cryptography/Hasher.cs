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
using System;
using System.Security.Cryptography;
using System.Text;

namespace Services.DesertMusic.Api.Utilities.Cryptography
{
		public static class Hasher
		{
				public static string CreateHash<T>(T obj)
				{
						var toHash = GetStringToHash(obj);

						using (var md5 = MD5.Create())
						{
								var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(toHash));
								var hash = Convert.ToBase64String(hashBytes);

								return hash;
						}
				}

				private static string GetStringToHash<T>(T obj)
				{
						var toHash = typeof(T) == typeof(string) ? obj.ToString() : JsonConvert.SerializeObject(obj);

						return toHash;
				}
		}
}

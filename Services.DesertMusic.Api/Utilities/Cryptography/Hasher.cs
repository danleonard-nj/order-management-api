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

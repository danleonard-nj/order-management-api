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


using Microsoft.AspNetCore.Http;
using System;
using System.Security.Authentication;

namespace Services.DesertMusic.Api.Utilities.Extensions
{
		public static class CommonExtensions
		{
				public static string AppendLine(this string value, string toAppend)
				{
						return value + Environment.NewLine + toAppend;
				}

				public static string GetBearer(this HttpRequest request)
				{
						if (request.Headers.ContainsKey("Authorization"))
						{
								var header = request.Headers["Authorization"].ToString();

								var bearer = header.Split(" ")[1];

								return bearer;
						}

						else
						{
								throw new AuthenticationException("No authorization found in request.");
						}	
				}
		}
}

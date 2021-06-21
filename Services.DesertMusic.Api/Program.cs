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


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Services.DesertMusic.Api
{
		public class Program
		{
				public static void Main(string[] args)
				{
						CreateHostBuilder(args).Build().Run();
				}

				public static IHostBuilder CreateHostBuilder(string[] args) =>
						Host.CreateDefaultBuilder(args)
								.ConfigureLogging(options =>
								{
										options.AddConsole();
										options.AddDebug();
								})
								.ConfigureWebHostDefaults(webBuilder =>
								{
										webBuilder.UseStartup<Startup>();
								});
		}
}

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


using Common.Utilities.AspNetCore;
using Common.Utilities.Configuration.Managed;
using Common.Utilities.Jwt.Middleware;
using Common.Utilities.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.DesertMusic.Api.Configuration;
using System.Reflection;

namespace Services.DesertMusic.Api
{
		public class Startup
		{
				public Startup(IConfiguration configuration,
						IWebHostEnvironment hostEnvironment)
				{
						Configuration = configuration;
						ManagedConfiguration = new ManagedConfiguration(hostEnvironment);

						_hostEnvironment = hostEnvironment;
				}

				public IManagedConfiguration ManagedConfiguration { get; set; }

				public IConfiguration Configuration { get; }

				// This method gets called by the runtime. Use this method to add services to the container.
				public void ConfigureServices(IServiceCollection services)
				{
						services.AddControllers();

						var aspNetCoreOptions = new AspNetCoreConfigurationOptions
						{
								TokenLifetime = 60
						};

						if (_hostEnvironment.IsProduction())
						{
								aspNetCoreOptions.InjectAzureKeyVaultSecrets = true;
						}

						services.ConfigureAspNetCoreServices<DependencyExports>(_hostEnvironment, aspNetCoreOptions);
				}

				// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
				public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
				{
						app.ConfigureSwagger(Assembly.GetExecutingAssembly().GetName().Name);

						if (env.IsDevelopment())
						{
								app.UseDeveloperExceptionPage();
						}

						app.UseHttpsRedirection();

						app.UseRouting();

						app.UseAuthorization();

						app.UseMiddleware<JwtMiddleware>();

						app.UseEndpoints(endpoints =>
						{
								endpoints.MapControllers();
						});
				}

				private readonly IWebHostEnvironment _hostEnvironment;
		}
}

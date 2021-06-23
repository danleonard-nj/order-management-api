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


using Common.Utilities.AspNetCore.Extensions;
using Common.Utilities.Authentication.Jwt.Configuration;
using Common.Utilities.Middleware.Authentication;
using Common.Utilities.Swagger;
using Common.Utilities.UserManagement.Settings;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
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
						_hostEnvironment = hostEnvironment;

						Configuration = configuration;
				}

				public IConfiguration Configuration { get; }

				// This method gets called by the runtime. Use this method to add services to the container.
				public void ConfigureServices(IServiceCollection services)
				{
						services.AddApplicationInsightsTelemetry();

						services.AddControllers();

						services.ConfigureAspNetCoreServices<DependencyExports>(_hostEnvironment);

						services.ConfigureJwtAuthentication(Configuration);

						services.AddApplicationInsightsTelemetry();

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

						app.UseAuthentication();

						app.UseMiddleware<JwtMiddleware>();

						app.UseEndpoints(endpoints =>
						{
								endpoints.MapControllers();
						});
				}

				private readonly IWebHostEnvironment _hostEnvironment;
		}
}

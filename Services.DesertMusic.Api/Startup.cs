using Common.Utilities.AspNetCore.Extensions;
using Common.Utilities.Authentication.Jwt.Configuration;
using Common.Utilities.Middleware.Authentication;
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
				public Startup(IConfiguration configuration)
				{
						Configuration = configuration;
				}

				public IConfiguration Configuration { get; }

				// This method gets called by the runtime. Use this method to add services to the container.
				public void ConfigureServices(IServiceCollection services)
				{
						services.AddControllers();

						services.ConfigureAspNetCoreServices<DependencyExports>();

						services.ConfigureJwtAuthentication(Configuration);
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
		}
}

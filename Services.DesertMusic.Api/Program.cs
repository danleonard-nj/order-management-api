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
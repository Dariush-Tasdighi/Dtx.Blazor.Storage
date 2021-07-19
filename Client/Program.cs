using Dtx.Blazor;
//using Dtx.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
	public class Program
	{
		public static async System.Threading.Tasks.Task Main(string[] args)
		{
			var builder =
				Microsoft.AspNetCore.Components.WebAssembly
				.Hosting.WebAssemblyHostBuilder.CreateDefault(args);

			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped
				(sp => new System.Net.Http.HttpClient
				{ BaseAddress = new System.Uri(builder.HostEnvironment.BaseAddress) });

			// using Dtx.Blazor;
			// using Dtx.AspNetCore;
			builder.Services.AddLocalStorage();

			// using Dtx.Blazor;
			// using Dtx.AspNetCore;
			builder.Services.AddSessionStorage();

			await builder.Build().RunAsync();
		}
	}
}

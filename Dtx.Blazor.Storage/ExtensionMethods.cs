using Microsoft.Extensions.DependencyInjection;

namespace Dtx.Blazor
{
	public static class ExtensionMethods
	{
		static ExtensionMethods()
		{
		}

		public static void AddLocalStorage
			(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			// using Microsoft.Extensions.DependencyInjection;
			services.AddScoped(serviceType: typeof(LocalStorage));
		}

		public static void AddSessionStorage
			(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			// using Microsoft.Extensions.DependencyInjection;
			services.AddScoped(serviceType: typeof(SessionStorage));
		}
	}
}

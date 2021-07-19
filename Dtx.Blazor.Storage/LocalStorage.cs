using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;

namespace Dtx.Blazor
{
	public class LocalStorage : object
	{
		public LocalStorage(Microsoft.JSInterop.IJSRuntime jsRuntime) : base()
		{
			JSRuntime = jsRuntime;
		}

		protected Microsoft.JSInterop.IJSRuntime JSRuntime { get; }

		public async System.Threading.Tasks.Task SetAsync<T>(string key, T value)
		{
			string jsValue = null;

			if (value != null)
			{
				jsValue =
					System.Text.Json.JsonSerializer.Serialize(value: value);
			}

			// using Microsoft.JSInterop;
			await JSRuntime.InvokeVoidAsync
				(identifier: "localStorage.setItem", args: new object[] { key, jsValue });
		}
		public async System.Threading.Tasks.Task<T> GetAsync<T>(string key)
		{
			string jsValue =
				await JSRuntime.InvokeAsync<string>
				(identifier: "localStorage.getItem", args: key);

			if (jsValue == null)
			{
				return default;
			}

			T value =
				System.Text.Json.JsonSerializer.Deserialize<T>(json: jsValue);

			return value;
		}

		public async System.Threading.Tasks.Task RemoveAsync(string key)
		{
			await JSRuntime.InvokeVoidAsync
				(identifier: "localStorage.removeItem", args: key);
		}

		public async System.Threading.Tasks.Task ClearAsync()
		{
			await JSRuntime.InvokeVoidAsync(identifier: "localStorage.clear");
		}
	}

	public static class LocalStorageExtensionMethods
	{
		static LocalStorageExtensionMethods()
		{
		}

		public static void AddLocalStorage
			(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			// using Microsoft.Extensions.DependencyInjection;
			services.AddScoped(serviceType: typeof(LocalStorage));
		}
	}
}

using Microsoft.JSInterop;

namespace Dtx.Blazor
{
	public abstract class Storage : object
	{
		protected Storage(Microsoft.JSInterop.IJSRuntime jsRuntime, string type) : base()
		{
			Type = type;
			JSRuntime = jsRuntime;
		}

		protected string Type { get; }

		protected Microsoft.JSInterop.IJSRuntime JSRuntime { get; }

		public async System.Threading.Tasks.Task SetAsync<T>(string key, T value)
		{
			string jsValue =
				System.Text.Json.JsonSerializer.Serialize(value: value);

			// using Microsoft.JSInterop;
			await JSRuntime.InvokeVoidAsync
				(identifier: $"{Type}Storage.setItem", args: new object[] { key, jsValue });
		}
		public async System.Threading.Tasks.Task<T> GetAsync<T>(string key)
		{
			string jsValue =
				await JSRuntime.InvokeAsync<string>
				(identifier: $"{Type}Storage.getItem", args: key);

			if (string.IsNullOrWhiteSpace(value: jsValue))
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
				(identifier: $"{Type}Storage.removeItem", args: key);
		}

		public async System.Threading.Tasks.Task ClearAsync()
		{
			await JSRuntime.InvokeVoidAsync
				(identifier: $"{Type}Storage.clear");
		}
	}
}
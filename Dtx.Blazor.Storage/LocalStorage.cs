namespace Dtx.Blazor
{
	public class LocalStorage : Storage
	{
		public LocalStorage
			(Microsoft.JSInterop.IJSRuntime jsRuntime) : base(jsRuntime: jsRuntime, type: "local")
		{
		}
	}
}

namespace Dtx.Blazor
{
	public class SessionStorage : Storage
	{
		public SessionStorage
			(Microsoft.JSInterop.IJSRuntime jsRuntime) : base(jsRuntime: jsRuntime, type: "session")
		{
		}
	}
}

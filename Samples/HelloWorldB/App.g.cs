using Lesarde.Frogui;
using HelloWorldB;

namespace HelloWorldB
{
	public partial class App : Lesarde.Frogui.SinglePageApplication
	{
		// InitializeComponent()
		public void InitializeComponent()
		{
			// Indicate that the WebAssembly scope should be used.
			this.ScopeType = typeof(Lesarde.Frogui.Scope);
			
			// Indicate that the HelloWorldB.Greeting class is this app's root element
			this.StartupType = typeof(HelloWorldB.Greeting);
		}
	}
}

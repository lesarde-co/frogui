/*
 * Demonstrates the classic "Hello, World!" app. It:
 *		- is a C# .NET Standard dll project -- the only option at the moment for frogui.
 *		- has an <OutputType> property added to the project file so the "Main" method entry point can be found; dll's do not have entry points by default.
 *		- has the Lesarde.Frogui.Wasm NuGet package added.
 *		- may be run as-is within a browser.
 *		- is not debuggable in its current form. See the HelloDebugger project to learn more.
 */

namespace HelloWorld
{
	class Program
	{
		static void Main(string[] args)
		{
			// Create and run the app
			var app = new App();
			app.Run();
		}
	}
}
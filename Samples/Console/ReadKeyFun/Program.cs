/*
 * Demonstrates how to read console input. It:
 *		- is a C# .NET Standard dll project -- the only option at the moment for frogui.
 *		- has an <OutputType> property added to the project file so the "Main" method entry point can be found; dll's do not have entry points by default.
 *		- has the Lesarde.Frogui.Wasm NuGet package added.
 *		- may be run as-is within a browser.
 */

namespace ReadKeyFun
{
	/***************************************************************************************************
		Program class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates how to read key entry into a console.
	/// </summary>
	class Program
	{
		/// <summary>
		/// This is the app entry point. Console processing should be done in
		/// <see cref="App.MainAsync"/>.
		/// </summary>
		static void Main(string[] args)
		{
			// Create and run the app
			var app = new App();
			app.ScopeType = typeof(Lesarde.Frogui.Scope);

			app.Run();
		}
	}
}

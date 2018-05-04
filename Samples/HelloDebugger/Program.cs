/*
 * Demonstrates how to debug a frogui app. It:
 *		- is a C# .NET Standard dll project -- the only option at the moment for frogui.
 *		- has an <OutputType> property added to the project file so the "Main" method entry point can be found; dll's do not have entry points by default.
 *		- has the Lesarde.Frogui.Wasm NuGet package added.
 *		- may be run as-is within a browser.
 *		- is meant to be debugged using the HelloDebuggerWin project.
 */

using Lesarde;
using System.Threading.Tasks;

namespace HelloDebugger
{
	// Make public so that HelloDebuggerWin can access
	public class Program
	{
		static void Main(string[] args)
		{
			// Call async method
			MainAsync(args);
		}

		// This is the body of the Main method, made public and async so it can be called by a Windows Console app for debugging purposes
		public static async void MainAsync(string[] args)
		{
			Console.WriteLine("Hello, Debugger!");

			// Await nothing so compiler don't warn
			await Task.CompletedTask;
		}
	}
}
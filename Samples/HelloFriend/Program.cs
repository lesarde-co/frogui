/*
 * Demonstrates how to read console input. It:
 *		- is a C# .NET Standard dll project -- the only option at the moment for frogui.
 *		- has an <OutputType> property added to the project file so the "Main" method entry point can be found; dll's do not have entry points by default.
 *		- has the Lesarde.Frogui.Wasm NuGet package added.
 *		- may be run as-is within a browser.
 */


using Lesarde;

namespace HelloFriend
{
	class Program
	{
		static void Main(string[] args)
		{
			// Call async method
			MainAsync(args);
		}

		// This is the body of the Main method, made async for good UI
		// performance and public for debugging purposes
		public static async void MainAsync(string[] args)
		{
			Console.ForegroundColor = System.ConsoleColor.Green;
			Console.BackgroundColor = System.ConsoleColor.Black;
			Console.Clear();

			// Prompt user for name
			Console.WriteLine("What is your name?");

			// Asynchronously read the line
			var name = await Console.ReadLineAsync();

			// Say hello
			Console.WriteLine(string.Format("Hello, {0}!", name));
		}
	}
}

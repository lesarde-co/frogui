using Lesarde.Frogui;
using System.Threading.Tasks;

namespace HelloWorldA
{
	/***************************************************************************************************
		App class
	***************************************************************************************************/
	/// <summary>
	/// Used for this application's <see cref="Application"/> singleton object, deriving from
	/// <see cref="ConsoleApplication"/> which all console apps must do.
	/// </summary>
	public class App : ConsoleApplication
    {
		/// <summary>
		/// This is where console interaction begins, much like the static main() 
		/// method in a traditional console app.
		/// </summary>
		public async override Task MainAsync()
		{
			// Greet the world
			Console.WriteLine("Hello, World!");

			// This await is optional but prevents a compiler warning since this method is async.
			await Task.CompletedTask;
		}
	}
}

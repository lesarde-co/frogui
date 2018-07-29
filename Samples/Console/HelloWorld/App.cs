using Lesarde.Frogui;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class App : ConsoleApplication
    {
		public async override Task MainAsync()
		{
			// Greet the world
			Console.WriteLine("Hello, World!");

			// This await is optional but prevents a compiler warning since this method is async.
			await Task.CompletedTask;
		}
	}
}

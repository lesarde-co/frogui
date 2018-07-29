using Lesarde.Frogui;
using System.Threading.Tasks;

namespace HelloFriend
{
    public class App : ConsoleApplication
    {
		// This is the main method associated with this console app. It is equivalent
		// to the Main method in a traditional .NET console application.
		public async override Task MainAsync()
		{
			var mainColor = System.ConsoleColor.Green;
			var inputColor = System.ConsoleColor.Yellow;

			Console.ForegroundColor = System.ConsoleColor.Green;
			Console.BackgroundColor = System.ConsoleColor.Black;
			Console.Clear();

			Console.ForegroundColor = mainColor;
			Console.Write("Enter your name:");

			Console.ForegroundColor = inputColor;
			var name = await Console.ReadLineAsync();

			Console.ForegroundColor = mainColor;
			Console.Write("Enter your age:");

			Console.ForegroundColor = inputColor;
			var age = await Console.ReadLineAsync();

			Console.ForegroundColor = System.ConsoleColor.Green;
			Console.WriteLine($"Hello, {name}! It's nice to meet you. {age} is a good age!");
		}

	}
}

using Lesarde.Frogui;
using System.Threading.Tasks;

namespace HelloFriend
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
			var outputColor = System.ConsoleColor.Green;
			var inputColor = System.ConsoleColor.Yellow;

			Console.ForegroundColor = System.ConsoleColor.Green;
			Console.BackgroundColor = System.ConsoleColor.Black;
			Console.Clear();

			Console.ForegroundColor = outputColor;
			Console.Write("Enter your name:");

			Console.ForegroundColor = inputColor;
			var name = await Console.ReadLineAsync();

			Console.ForegroundColor = outputColor;
			Console.Write("Enter your age:");

			Console.ForegroundColor = inputColor;
			var age = await Console.ReadLineAsync();

			Console.ForegroundColor = outputColor;
			Console.WriteLine("Hello, " + name + "! It's nice to meet you. " + age + " is a good age!");
		}

	}
}

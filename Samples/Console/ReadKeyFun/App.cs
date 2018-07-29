using Lesarde.Frogui;
using System.Threading.Tasks;

namespace ReadKeyFun
{
    public class App : ConsoleApplication
    {
		// This is the main method associated with this console app. It is equivalent
		// to the Main method in a traditional .NET console application.
		public async override Task MainAsync()
		{
			var sysForeground = System.ConsoleColor.White;

			Console.BackgroundColor = System.ConsoleColor.DarkBlue;
			Console.Clear();

			Console.ForegroundColor = sysForeground;
			Console.WriteLine("Press any key to start the fun, including special keys such as [F1], [->], [Enter/Return], number pad, etc.");
			Console.WriteLine("Modify by simultaneously pressing [Shift], [Ctrl], [Alt], [Windows or ⌘].");
			Console.WriteLine("[Esc] to quit");

			Console.ForegroundColor = System.ConsoleColor.Cyan;

			System.ConsoleKey ck = System.ConsoleKey.NoName;
			while (System.ConsoleKey.Escape != ck)
			{
				var value = await Console.ReadKeyAsync();
				ck = value.Key;
				var s = ck.ToString();
				if (value.Modifiers != 0)
					s += " " + value.Modifiers.ToString();
				Console.WriteLine(s);
			};

			Console.ForegroundColor = sysForeground;
			Console.WriteLine();
			Console.WriteLine("All done!");

		}

	}
}

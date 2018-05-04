/*
 * Demonstrates how to debug a frogui app. It:
 *		- is a C# .NET Core app project.
 *		- references HelloDebugger project.
 *		- may be run in Visual Studio's debugger.
 */

namespace HelloDebuggerWin
{
    class Program
    {
        static void Main(string[] args)
        {
			// Call into HelloDebugger
			HelloDebugger.Program.Go(args);
        }
    }
}

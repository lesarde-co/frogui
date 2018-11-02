using System;

namespace HelloWorldC
{
	/***************************************************************************************************
		Program class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the classic Hello World app.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// This is the app entry point.
		/// </summary>
		static void Main(string[] args)
		{
			// Create and run a new app object
			var app = new App();
			app.Run();

			// Your code here, though generally app-level code should be added to the App class, which
			// is the singleton that is created above.
		}
	}
}
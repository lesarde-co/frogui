using System;

namespace HelloWorld
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
		}
	}
}
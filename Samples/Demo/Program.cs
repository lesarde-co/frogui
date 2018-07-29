/***************************************************************************************************
	Demonstrates...
***************************************************************************************************/

using System;

namespace Demo
{
	/***************************************************************************************************
		Program class
	***************************************************************************************************/
	/// <summary>
	/// This class contain the the app's <see cref="Main(string[])"/> entry point method.
	/// </summary>
	public class Program
	{
		static void Main(string[] args)
		{
			try
			{
				// Create and run the app
				var app = new App();
				app.Run();
			}
			// TODO:Is not catching exceptions here.
			catch (Exception x)
			{
				App.Current.Alert(x.ToString());
			}
		}
	

	}
}
/*
 * Demonstrates...
 */

using System;

namespace HelloWorld
{
	public class Program
	{
		static void Main(string[] args)
		{
//			try
	//		{
				
				System.Console.WriteLine("Main(*)");
				// Create and run the app
				var app = new App();
				app.InitializeComponent();
				app.Run();
			//}
			//catch (Exception x)
			//{
			//	System.Console.WriteLine("Exception!");
			//	System.Console.WriteLine(x.ToString());
			//}
		}
	}
}
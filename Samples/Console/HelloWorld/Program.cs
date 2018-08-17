namespace HelloWorld
{
	/***************************************************************************************************
		Program class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the classic Hello World app in a console.
	/// </summary>
	class Program
	{
		/// <summary>
		/// This is the app entry point. Console processing should be done in
		/// <see cref="App.MainAsync"/>.
		/// </summary>
		static void Main(string[] args)
		{
			// Create and run the app
			var app = new App();
			app.Run();
		}
	}
}
namespace HelloFriend
{
	/***************************************************************************************************
		Program class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates how to read and write to the console.
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
			app.ScopeType = typeof(Lesarde.Frogui.Scope);

			app.Run();
		}
	}
}

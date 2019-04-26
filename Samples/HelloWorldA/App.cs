using Lesarde.Frogui;

namespace HelloWorldA
{
	/***************************************************************************************************
		App class
	***************************************************************************************************/
	/// <summary>
	/// Used for this application's <see cref="Application"/> singleton object, deriving from
	/// <see cref="SinglePageApplication"/> which all single-page apps must do.
	/// Note that this is a partial class because it is the code-behind for the App.xaml file.
	/// </summary>
	public partial class App : SinglePageApplication
    {
		/*******************************************************************************
			$
		*******************************************************************************/
		/// <summary>
		/// Creates an <see cref="App"/> object.
		/// </summary>
		public App()
		{
			InitializeComponent();

			// Add your code here
		}
	}
}

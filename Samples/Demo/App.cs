using Lesarde.Frogui;
using Lesarde.Frogui.Input;

namespace Demo
{
	/***************************************************************************************************
		App class (code-behind)
	***************************************************************************************************/
	/// <summary>
	/// The application object singleton. <see cref="App"/> inherits from
	/// <see cref="SinglePageApplication"/>, which indicates that it is meant to be a Single Page GUI
	/// Application (SPA).
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

			// Add user code here
		}
	}
}
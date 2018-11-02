using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace HelloWorldC
{
	/***************************************************************************************************
		Greeting class
	***************************************************************************************************/
	/// <summary>
	/// This class is a <see cref="TextBlock"/> that displays "Hello, World!".
	/// Note this is a partial class.
	/// </summary>
	public partial class Greeting
		:
	TextBlock, // Inherit from TextBlock to keep the design simple
	IViewOfViewModel<ViewModel> // Indicate that this is a view of the ViewModel class
    {
		/// <summary>
		/// Provides a type-safe property to access the associated model.
		/// </summary>
		public ViewModel ViewModel
		{
			get => (ViewModel)DataContext;
			set => DataContext = value;
		}

		public Greeting()
		{
			// Allow the design.cs file to initialize
			InitializeComponent();

			// For simplicity, create and assign the ViewModel property here. There are no specific rules about
			// when and how to associate a view with a view-model. Just keep in mind that a view is of little
			// use without a view-model.
			ViewModel = new ViewModel();
		}

	}
}

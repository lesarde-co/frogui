using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace HelloWorldB
{
	/***************************************************************************************************
		Greeting class
	***************************************************************************************************/
	/// <summary>
	/// This class inherits from <see cref="TextBlock"/>, and displays "Hello, World!".
	/// </summary>
	public partial class Greeting
		:
	TextBlock, // Inherit from TextBlock to keep the design simple
	IViewOfModel<Model> // Indicate that this class is a view of the Model class
    {
		public object ModelObject
		{
			get => DataContext;
			set => DataContext = value;
		}

		/// <summary>
		/// Provides a type-safe property to access the associated model.
		/// </summary>
		public Model Model => (Model)ModelObject;

		public Greeting()
		{
			// Allow the design.cs file to initialize
			InitializeComponent();

			// For simplicity, create and assign the Model property here. There are no specific rules about
			// when and how to associate a view with a model. Just keep in mind that a view is of little
			// use without a model.
			ModelObject = new Model();
		}

	}
}

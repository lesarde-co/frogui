using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace HelloWorld
{
	/***************************************************************************************************
		Greeting class
	***************************************************************************************************/
	/// <summary>
	/// This class is a <see cref="TextBlock"/> that displays "Hello, World!". Note that this approach
	/// is contrived for demonstration purposes.
	/// Note this is a partial class.
	/// </summary>
	public partial class Greeting : TextBlock
    {
		public Greeting()
		{
			// Allow the design.cs file to initialize
			InitializeComponent();
		}
	}
}

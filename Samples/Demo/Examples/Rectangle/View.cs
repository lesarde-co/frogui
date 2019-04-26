using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_Rectangle
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Rectangle"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		Element IExampleView.MainElement => e_rectangle;

		public View()
		{
			InitializeComponent();
		}
	}
}
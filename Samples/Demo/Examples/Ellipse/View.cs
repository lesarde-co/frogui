using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_Ellipse
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Rectangle"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		Element IExampleView.MainElement => e_ellipse;

		public View()
		{
			InitializeComponent();
		}
	}
}


using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_Border
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Border"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		Element IExampleView.MainElement => e_border;

		public View()
		{
			InitializeComponent();
		}
	}
}
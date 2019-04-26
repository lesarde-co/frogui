using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo.Example_Button
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Button"/> class.
	/// </summary>
	public partial class View : Decorator, IExampleView
    {
		public View()
		{
			InitializeComponent();
		}

		Element IExampleView.MainElement => e_button;
	}
}

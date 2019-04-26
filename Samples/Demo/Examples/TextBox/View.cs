using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_TextBox
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="TextBox"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		Element IExampleView.MainElement => e_textBox;

		public View()
		{
			InitializeComponent();
		}
	}
}
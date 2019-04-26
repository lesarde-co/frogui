using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_TextBlock
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="TextBlock"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		Element IExampleView.MainElement => e_textBlock;

		public View()
		{
			InitializeComponent();
		}
	}
}
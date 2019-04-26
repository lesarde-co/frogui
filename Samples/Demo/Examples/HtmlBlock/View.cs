using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo.Example_HtmlBlock
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="HtmlBlock"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		Element IExampleView.MainElement => e_htmlBlock;

		public View()
		{
			InitializeComponent();
		}
	}
}
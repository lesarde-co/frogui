using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo.Example_NumericEdit
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="NumericEdit"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		Element IExampleView.MainElement => e_numericEdit;

		public View()
		{
			InitializeComponent();
		}
	}
}


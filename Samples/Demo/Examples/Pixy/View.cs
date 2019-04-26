using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo.Example_Pixy
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Pixy"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		Element IExampleView.MainElement => e_pixy;

		public View()
		{
			InitializeComponent();
		}
	}
}
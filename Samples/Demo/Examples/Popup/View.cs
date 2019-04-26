using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_Popup
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Popup"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		/***********************************************************
			MainElement property
		***********************************************************/

		Element IExampleView.MainElement => e_popup;

		/*******************************************************************************
			$
		*******************************************************************************/

		public View()
		{
			InitializeComponent();
		}
	}
}

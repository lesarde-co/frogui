using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_ScrollViewer
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="ScrollViewer"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		/***********************************************************
			MainElement property
		***********************************************************/

		Element IExampleView.MainElement => e_scrollViewer;

		/*******************************************************************************
			$
		*******************************************************************************/

		public View()
		{
			InitializeComponent();
		}
	}
}

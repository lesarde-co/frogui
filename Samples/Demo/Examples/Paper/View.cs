using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo.Example_Paper
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Grid"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		/***********************************************************
			MainElement property
		***********************************************************/

		Element IExampleView.MainElement => e_paper;

		/*******************************************************************************
			$
		*******************************************************************************/

		public View()
		{
			InitializeComponent();
		}

	}
}

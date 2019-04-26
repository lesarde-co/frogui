using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo.Example_CheckBox
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="CheckBox"/> class.
	/// </summary>
	public partial class View : Flex, IExampleView
    {
		public View()
		{
			InitializeComponent();
		}

		Element IExampleView.MainElement => e_checkBox;
	}
}

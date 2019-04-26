using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo.Example_ListBox
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="ListBox"/> class.
	/// </summary>
	public partial class View : Decorator, IExampleView
    {
		Element IExampleView.MainElement => e_listBox;

		public View()
		{
			InitializeComponent();

			e_listBox.ItemViewMatcher = Common.ItemsControlViewMatcher;
		}
	}
}

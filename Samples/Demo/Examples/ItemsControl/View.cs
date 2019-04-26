using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Shapes;

namespace Demo.Example_ItemsControl
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="CheckBox"/> class.
	/// </summary>
	public partial class View : Decorator, IExampleView
    {
		public View()
		{
			InitializeComponent();

			e_itemsControl.ItemViewMatcher = Common.ItemsControlViewMatcher;
		}

		Element IExampleView.MainElement => e_itemsControl;
	}
}

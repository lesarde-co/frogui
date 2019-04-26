using Lesarde.Frogui;
using Lesarde.Frogui.Controls;

namespace Demo.Example_Droplist
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Droplist"/> class.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		Element IExampleView.MainElement => e_droplist;

		public View()
		{
			InitializeComponent();

			e_droplist.ItemViewMatcher = Common.ItemsControlViewMatcher;
		}
	}
}

using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo
{
	/***************************************************************************************************
		MainWindow class (design)
	***************************************************************************************************/
	public partial class MainWindow : Window
	{
		/***********************************************************
			elements
		***********************************************************/

		Grid
			e_grid;

		Flex
			e_buttons;

		ScrollViewer
			e_scollViewer;

		/*******************************************************************************
			InitializeComponent()
		*******************************************************************************/

		public void InitializeComponent()
		{
			// Create and add a grid as this window's child
			e_grid = new Grid();
			e_grid.ColumnDefinitions
				.Add(new ColumnDefinition() { Width = GridLength.Auto })
				.Add(new ColumnDefinition() { Width = new GridLength(new Length(1, Unit.Fr)) });

			Child = e_grid;

			// Create a flex element used to contain buttons. Add it to the grid.
			e_buttons = new Flex()
			{
				Direction = FlexDirection.Column,
				Wrapping = FlexWrapping.NoWrap,
				Background = new SolidColorBrush(Color.FromRgb(0x00, 0x00, 0x33)),
				Width = new Length(160, Unit.Px)
			};
			e_grid.Children.Add(e_buttons);

			e_scollViewer = new ScrollViewer()
			{
				HorizontalAlignment = HorizontalAlignment.Stretch,
				VerticalAlignment = VerticalAlignment.Stretch,
				HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
				VerticalScrollBarVisibility = ScrollBarVisibility.Auto
			};

			e_grid.Children.Add(e_scollViewer, new Grid.Anchor(1, 0));
		}
	}
}

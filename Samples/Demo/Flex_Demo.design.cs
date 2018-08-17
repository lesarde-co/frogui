using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Input;
using Lesarde.Frogui.Media;

namespace Demo
{
	public partial class Flex_Demo : Grid
	{
		Flex e_flex;

		//TextBlock
			//e_direction,
			//e_direction_row,
			//e_direction_reverseRow,
			//e_direction_column,
			//e_direction_reverseColumn,
			//e_wrap,
			//e_wrap_no,
			//e_wrap_wrap,
			//e_wrap_reverse;

		FontSize fontSize = FontSize.FromKind(FontSizeKind.Large);
		
		Brush
			selectedBrush = Common.GetSolidColorBrush(Colors.Yellow),
			unselectedBrush = Common.GetSolidColorBrush(Colors.DimGray);

		TextBlock
			selectedDirection,
			selectedWrapping;

		public void InitializeComponent()
		{
			ColumnDefinitions.Add(new ColumnDefinition());
			ColumnDefinitions.Add(new ColumnDefinition());
			ColumnDefinitions.Add(new ColumnDefinition());
			ColumnDefinitions.Add(new ColumnDefinition());
			ColumnDefinitions.Add(new ColumnDefinition());

			RowDefinitions.Add(new RowDefinition(new GridLength(new Length(40, Unit.Px))));
			RowDefinitions.Add(new RowDefinition(new GridLength(new Length(40, Unit.Px))));
			RowDefinitions.Add(new RowDefinition(new GridLength(new Length(1, Unit.Fr))));

			AddTitle("Direction:", 0, 0);

			var e_direction_row = AddOption("Row", 1, 0, FlexDirection.Row, ChangeDirection);
			AddOption("Reverse Row", 2, 0, FlexDirection.RowReverse, ChangeDirection);
			AddOption("Column", 3, 0, FlexDirection.Column, ChangeDirection);
			AddOption("Reverse Column", 4, 0, FlexDirection.ColumnReverse, ChangeDirection);

			AddTitle("Wrap:", 0, 1);

			var e_wrapping_no = AddOption("No Wrap", 1, 1, FlexWrapping.NoWrap, ChangeWrapping);
			AddOption("Wrap", 2, 1, FlexWrapping.Wrap, ChangeWrapping);
			AddOption("Reverse Wrap", 3, 1, FlexWrapping.WrapReverse, ChangeWrapping);

			e_flex = new Flex()
			{
				Direction = FlexDirection.RowReverse,
				Wrapping = FlexWrapping.WrapReverse,
			};

			Children.Add(e_flex, new Grid.Anchor(0, 5, 2, 1));

			SelectDirection(e_direction_row);
			SelectWrapping(e_wrapping_no);
		}

		/* AddTitle() */
		TextBlock AddTitle(string text, int column, int row)
		{
			var element = AddTextBlock(text, column, row, Common.GetSolidColorBrush(Colors.White));

			element.FontWeight = new FontWeight(FontWeightKind.Bold);
			element.Margin = new Thickness(new Length(8, Unit.Px));
			return element;
		}

		/* AddOption() */
		TextBlock AddOption(string text, int column, int row, object tag, PointerEventHandler handler)
		{
			var element = AddTextBlock(text, column, row, unselectedBrush);

			element.Tag = tag;
			element.PointerPressed += handler;

			return element;
		}

		/* AddTextBlock() */
		TextBlock AddTextBlock(string text, int column, int row, Brush foreground)
		{
			var element = new TextBlock()
			{
				Text = text,
				Foreground = foreground,
				VerticalAlignment = VerticalAlignment.Center,
				FontSize = fontSize,
				Selectable = false
			};

			Children.Add(element, new Grid.Anchor(column, row));

			return element;
		}

		void ChangeDirection(object sender, PointerEventArgs e) => SelectDirection((TextBlock)sender);
		//{
		//	var element = (TextBlock)sender;
		//	var direction = (FlexDirection)element.Tag;
		//	e_flex.Direction = direction;
		//}

		void ChangeWrapping(object sender, PointerEventArgs e) => SelectWrapping((TextBlock)sender);
		//{
		//	var element = (TextBlock)sender;
		//	var wrapping = (FlexWrapping)element.Tag;
		//	e_flex.Wrapping = wrapping;
		//}

		void SelectDirection(TextBlock element)
		{
			if (null != selectedDirection)
				selectedDirection.Foreground = unselectedBrush;

			selectedDirection = element;

			element.Foreground = selectedBrush;

			var direction = (FlexDirection)element.Tag;
			e_flex.Direction = direction;
		}

		void SelectWrapping(TextBlock element)
		{
			if (null != selectedWrapping)
				selectedWrapping.Foreground = unselectedBrush;

			selectedWrapping = element;

			element.Foreground = selectedBrush;

			var wrapping = (FlexWrapping)element.Tag;
			e_flex.Wrapping = wrapping;
		}

	}
}

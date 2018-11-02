using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Input;
using Lesarde.Frogui.Media;

namespace Demo.Flex_Class
{
	/***************************************************************************************************
		Ellipse_Demo class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Flex"/> element.
	/// </summary>
	public partial class View : Grid
	{
		/***********************************************************
			Commands class
		***********************************************************/

		public static class Commands
		{
			public static Command Direction_Row { get; } = new Command();
			public static Command Direction_ReverseRow { get; } = new Command();
			public static Command Direction_Column { get; } = new Command();
			public static Command Direction_ReverseColumn { get; } = new Command();

			public static Command Wrapping_NoWrap { get; } = new Command();
			public static Command Wrapping_Wrap { get; } = new Command();
			public static Command Wrapping_ReverseWrap { get; } = new Command();
		}

		//Brush
			//selectedBrush = Common.GetSolidColorBrush(Colors.Yellow),
			//unselectedBrush = Common.GetSolidColorBrush(Colors.DimGray);

		TextBlock
			selectedDirection,
			selectedWrapping;

		public View()
		{
			InitializeComponent();

			Brush
				borderBrush = new SolidColorBrush(Colors.SeaShell),
				darkNumberBrush = Common.GetSolidColorBrush(Colors.Black),
				lightNumberBrush = Common.GetSolidColorBrush(Colors.Gray);

			var ballRadius = 40.0d;			
			var ballLength = new Length(ballRadius * 2, Unit.Px);
			var ballCornerRadius = new CornerRadius(new Length(ballRadius, Unit.Px));
			var numberFontSize = FontSize.FromKind(FontSizeKind.Large);

			for (var i = 0; i < 50; ++i)
			{
				var ballBackground = Common.SolidColorBrushes[i % Common.SolidColorBrushes.Length];
				var isBallDark = ballBackground.Color.R.Intensity + ballBackground.Color.G.Intensity + ballBackground.Color.B.Intensity < 0x180;

				var e_ball = new Border()
				{
					CornerRadius = ballCornerRadius,
					BorderBrush = borderBrush,
					Background = ballBackground,
					Width = ballLength,
					Height = ballLength
				};

				var e_number = new TextBlock()
				{
					Foreground = (isBallDark) ? lightNumberBrush : darkNumberBrush,
					Text = i.ToString(),
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center,
					FontSize = numberFontSize,
					Selectable = false
				};

				e_ball.Child = e_number;

				e_flex.Children.Add(e_ball);
			}

			SelectDirection(e_directionRowReverse);
			SelectWrapping(e_wrappingWrapReverse);
		}

		//void OnPointerPressed(object sender, PointerEventArgs e)
		//{
		//	var tb = (TextBlock)sender;

		//	if (tb.Tag is FlexDirection)
		//		SelectDirection(tb);
		//	else
		//		SelectWrapping(tb);
		//}

		void ChangeDirection(object sender, PointerEventArgs e) => SelectDirection((TextBlock)sender);

		void ChangeWrapping(object sender, PointerEventArgs e) => SelectWrapping((TextBlock)sender);

		void SelectDirection(TextBlock element)
		{
			if (null != selectedDirection)
				selectedDirection.Foreground = AssetSheet.Singleton.UnselectedBrush;

			selectedDirection = element;

			element.Foreground = AssetSheet.Singleton.SelectedBrush;

			var direction = (FlexDirection)element.Tag;
			e_flex.Direction = direction;
		}

		void SelectWrapping(TextBlock element)
		{
			if (null != selectedWrapping)
				selectedWrapping.Foreground = AssetSheet.Singleton.UnselectedBrush;

			selectedWrapping = element;

			element.Foreground = AssetSheet.Singleton.SelectedBrush;

			var wrapping = (FlexWrapping)element.Tag;
			e_flex.Wrapping = wrapping;
		}

	}
}

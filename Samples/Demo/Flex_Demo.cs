using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo
{
	/***************************************************************************************************
		Ellipse_Demo class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Flex"/> element.
	/// </summary>
	public partial class Flex_Demo : Grid
	{
		public Flex_Demo()
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
		}
	}
}

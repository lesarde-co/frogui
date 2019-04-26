using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo.Example_Flex
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Flex"/> element.
	/// </summary>
	public partial class View : Decorator, IExampleView
	{
		public View()
		{
			InitializeComponent();

			Brush
				borderBrush = SolidColorBrushes.SeaShell.Brush,
				darkNumberBrush = SolidColorBrushes.Black.Brush,
				lightNumberBrush = SolidColorBrushes.Gray.Brush;

			var ballRadius = 60.0d;			
			var ballLength = new Length(ballRadius * 2, Unit.Px);
			var ballCornerRadius = new CornerRadius(new Length(ballRadius, Unit.Px));
			var numberFontSize = FontSize.FromKind(FontSizeKind.Large);

			for (var i = 0; i < 30; ++i)
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
					FontSize = numberFontSize,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
					//Selectable = false
				};

				e_ball.Child = e_number;

				e_flex.Children.Add(e_ball);
			}
		}

		Element IExampleView.MainElement => e_flex;
	}
}

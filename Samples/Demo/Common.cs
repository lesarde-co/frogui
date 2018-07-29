using System;
using System.Collections.Generic;
using System.Linq;
using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Media.Imaging;
using Lesarde.Frogui.Shapes;

namespace Demo
{
	public static class Common
	{
		// Lorem Ipsum
		public const string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

		public static readonly Thickness Margin = new Thickness(new Length(5, Unit.Px));

		public static readonly BitmapImage lesardeLogoImage = new BitmapImage(new System.Uri("Resources/Lesarde-64.png", UriKind.Relative));

		public static readonly string[] StringMix =
		{
			LoremIpsum,
			"Hello",
			"Logic will get you from A to B. Imagination will take you everywhere."
		};

		public static readonly FontSize[] FontSizeMix =
		{
			FontSize.FromKind(FontSizeKind.XxLarge),
			FontSize.FromKind(FontSizeKind.Medium),
			FontSize.FromLength(12, Unit.Pt),
			FontSize.FromPercent(10)
		};

		public static readonly FontFamily[] FontFamilyMix =
		{
			new FontFamily("Times"),
			new FontFamily("Helvetica"),
			new FontFamily("Impact")
		};

		public static readonly FontWeight[] FontWeightMix =
		{
			new FontWeight(FontWeightKind.Lighter),
			new FontWeight(FontWeightKind.Normal),
			new FontWeight(FontWeightKind.Bold),
			new FontWeight(200)
		};

		public static readonly FontStyle[] FontStyleMix =
		{
			FontStyle.None,
			FontStyle.Normal,
			FontStyle.Italic,
			FontStyle.Oblique
		};

		public static readonly FontStretch[] FontStretchMix =
		{
			FontStretch.Condensed,
			FontStretch.Normal,
			FontStretch.SemiExpanded
		};

		// Solid Color Brushes
		public static readonly HashSet<SolidColorBrush> SolidColorBrushes = new HashSet<SolidColorBrush>()
		{
			{ new SolidColorBrush(Colors.Aqua) },
			{ new SolidColorBrush(Colors.Azure) },
			{ new SolidColorBrush(Colors.Black) },
			{ new SolidColorBrush(Colors.Blue) },
			{ new SolidColorBrush(Colors.Cyan) },
			{ new SolidColorBrush(Colors.DarkBlue) },
			{ new SolidColorBrush(Colors.DarkGray) },
			{ new SolidColorBrush(Colors.DarkMagenta) },
			{ new SolidColorBrush(Colors.DarkRed) },
			{ new SolidColorBrush(Colors.DarkSeaGreen) },
			{ new SolidColorBrush(Colors.DarkSlateBlue) },
			{ new SolidColorBrush(Colors.DarkViolet) },
			{ new SolidColorBrush(Colors.DimGray) },
			{ new SolidColorBrush(Colors.Gray) },
			{ new SolidColorBrush(Colors.Green) },
			{ new SolidColorBrush(Colors.Indigo) },
			{ new SolidColorBrush(Colors.LightGray) },
			{ new SolidColorBrush(Colors.LightBlue) },
			{ new SolidColorBrush(Colors.Lime) },
			{ new SolidColorBrush(Colors.Magenta) },
			{ new SolidColorBrush(Colors.MidnightBlue) },
			{ new SolidColorBrush(Colors.Orange) },
			{ new SolidColorBrush(Colors.Red) },
			{ new SolidColorBrush(Colors.SlateBlue) },
			{ new SolidColorBrush(Colors.Transparent) },
			{ new SolidColorBrush(Colors.Violet) },
			{ new SolidColorBrush(Colors.White) },
			{ new SolidColorBrush(Colors.Yellow) }
		};


		public static SolidColorBrush GetSolidColorBrush(Color color) => SolidColorBrushes.First((o) => o.Color == color);

		// Linear Gradient Brushes
		public static readonly LinearGradientBrush[] LinearGradientBrushes =
		{
			new LinearGradientBrush(
				new GradientStopCollection()
					.Add(new GradientStop(Colors.Red, new Length(0.0, Unit.Percent)))
					.Add(new GradientStop(Colors.Yellow, new Length(100.0, Unit.Percent)))
					),
			new LinearGradientBrush(
				new GradientStopCollection()
					.Add(new GradientStop(Colors.BlueViolet, new Length(0.0, Unit.Percent)))
					.Add(new GradientStop(Colors.MidnightBlue, new Length(50.0, Unit.Percent)))
					.Add(new GradientStop(Colors.DarkTurquoise, new Length(100.0, Unit.Percent))),
					new LinearGradientAngle(LinearGradientAngleKind.ToRight)
					)
		};

		// Radial Gradient Brushes
		public static readonly RadialGradientBrush[] RadialGradientBrushes =
		{
			new RadialGradientBrush(
				new GradientStopCollection()
					.Add(new GradientStop(Colors.MidnightBlue, new Length(0.0, Unit.Percent)))
					.Add(new GradientStop(Colors.Turquoise, new Length(100.0, Unit.Percent)))
					),
			new RadialGradientBrush(
				new GradientStopCollection()
					.Add(new GradientStop(Colors.Red, new Length(0.0, Unit.Percent)))
					.Add(new GradientStop(Colors.Orange, new Length(20.0, Unit.Percent)))
					.Add(new GradientStop(Colors.Yellow, new Length(35.0, Unit.Percent)))
					.Add(new GradientStop(Colors.Green, new Length(50.0, Unit.Percent)))
					.Add(new GradientStop(Colors.Blue, new Length(65.0, Unit.Percent)))
					.Add(new GradientStop(Colors.Indigo, new Length(80.0, Unit.Percent)))
					.Add(new GradientStop(Colors.Violet, new Length(100.0, Unit.Percent)))
					)
		};

		// Bitmaps
		public static readonly BitmapImage[] Bitmaps =
		{
			//new BitmapImage(new System.Uri("Resources/Island.png", UriKind.Relative)),
			new BitmapImage(new System.Uri("Resources/Scooby.png", UriKind.Relative)),
			new BitmapImage(new System.Uri("Resources/Simpsons.jpg", UriKind.Relative)),
			new BitmapImage(new System.Uri("Resources/Flintstones.jpg", UriKind.Relative)),
			new BitmapImage(new System.Uri("Resources/Jetsons.jpg", UriKind.Relative))
		};

		// Image Brushes
		public static readonly ImageBrush[] ImageBrushes =
		{
			new ImageBrush(Bitmaps[0]),
			new ImageBrush(Bitmaps[1]),
			new ImageBrush(Bitmaps[2]),
			new ImageBrush(Bitmaps[3])
		};

		public static readonly BorderPattern[] BorderPatterns =
		{
			new BorderPattern(StrokePattern.Solid),
			new BorderPattern(StrokePattern.Dotted),
			new BorderPattern(StrokePattern.Dashed),
			new BorderPattern(StrokePattern.Double),
			new BorderPattern(StrokePattern.Groove),
			new BorderPattern(StrokePattern.Ridge),
			new BorderPattern(StrokePattern.Inset),
			new BorderPattern(StrokePattern.Outset),
			new BorderPattern(StrokePattern.Solid, StrokePattern.Dotted, StrokePattern.Ridge, StrokePattern.Groove),
		};

		public static readonly Brush[] BrushesMix =
		{
			null,
			GetSolidColorBrush(Colors.Lime),
			GetSolidColorBrush(Colors.DarkMagenta),
			GetSolidColorBrush(Colors.White),
			LinearGradientBrushes[0],
			LinearGradientBrushes[1],
			RadialGradientBrushes[0],
			RadialGradientBrushes[1],
			ImageBrushes[2],
			ImageBrushes[3]
		};

		public static readonly Tuple<Length, Length>[] SizesMix =
		{
			new Tuple<Length, Length>(new Length(240, Unit.Px), new Length(160, Unit.Px)),
			new Tuple<Length, Length>(new Length(480, Unit.Px), new Length(320, Unit.Px))
		};

		public static readonly Thickness[] ThicknessMix =
		{
			//new Thickness(new Length(0, Unit.Px)),
			new Thickness(new Length(6, Unit.Px)),
			new Thickness(new Length(16, Unit.Px)),
			new Thickness(new Length(2, Unit.Px), new Length(8, Unit.Px), new Length(16, Unit.Px), new Length(4, Unit.Px))
		};

		public static readonly Length[] LengthMix =
		{
			new Length(6, Unit.Px),
			new Length(16, Unit.Px)
		};

		public static readonly Length[] WidthMix =
		{
			new Length(300, Unit.Px),
			new Length(25, Unit.Vw)
		};

		public static readonly Length[] RadiusMix =
		{
			new Length(0, Unit.Px),
			new Length(20, Unit.Px),
			new Length(100, Unit.Px)
		};

		public static readonly CornerRadius[] CornerRadiusMix =
		{
			new CornerRadius(new Length(0, Unit.Px)),
			new CornerRadius(new Length(10, Unit.Px)),
			new CornerRadius(new Length(5, Unit.Px), new Length(110, Unit.Px), new Length(0, Unit.Px), new Length(50, Unit.Px))
		};

		public static Grid PrepareDemoGrid(Grid e_grid, int totCols, int totRows, Brush bkgdBrush, Brush cellBrush)
		{
			var gap = new Length(10.0, Unit.Px);

			e_grid.ColumnGap = gap;
			e_grid.RowGap = gap;
			//e_grid.Padding = new Thickness(gap);
			e_grid.Background = bkgdBrush;			

			for (int col = 0; col < totCols; ++col)
				e_grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

			for (int row = 0; row < totRows; ++row)
				e_grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

			for (int col = 0; col < totCols; ++col)
				for (int row = 0; row < totRows; ++row)
				{
					var e_rect = new Rectangle()
					{
						Fill = cellBrush
					};

					e_grid.Children.Add(e_rect, new Grid.Anchor(col, row));
				}

			return e_grid;
		}

	}
}

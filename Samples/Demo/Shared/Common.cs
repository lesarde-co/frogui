using System;
using System.Linq;
using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Media.Imaging;
using Lesarde.Frogui.Shapes;

namespace Demo
{
	/***************************************************************************************************
		Common class
	***************************************************************************************************/
	/// <summary>
	/// Used to store items that are common for the demos.
	/// </summary>
	public static class Common
	{

		/***********************************************************
			...
		***********************************************************/

		// Lorem Ipsum
		public const string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

		public static readonly string[] LoremIpsumWords = LoremIpsum.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

		public static readonly Thickness Margin = new Thickness(new Length(5, Unit.Px));

		public static class FontFamilies
		{
			public static readonly FontFamily Arial = new FontFamily("Arial");
			public static readonly FontFamily ArialBlack = new FontFamily("Arial Black");
			public static readonly FontFamily Bookman = new FontFamily("Bookman");
			public static readonly FontFamily ComicSansMS = new FontFamily("Comic Sans MS");
			public static readonly FontFamily Courier = new FontFamily("Courier");
			public static readonly FontFamily CourierNew = new FontFamily("Courier New");
			public static readonly FontFamily Garmond = new FontFamily("Garamond");
			public static readonly FontFamily Georgia = new FontFamily("Georgia");
			public static readonly FontFamily Helvetica = new FontFamily("Helvetica");
			public static readonly FontFamily Impact = new FontFamily("Impact");
			public static readonly FontFamily Palatino = new FontFamily("Palatino");
			public static readonly FontFamily Times = new FontFamily("Times");
			public static readonly FontFamily TimesNewRoman = new FontFamily("Times New Roman");
			public static readonly FontFamily TrebuchetMS = new FontFamily("Trebuchet MS");
			public static readonly FontFamily Verdana = new FontFamily("Verdana");
		}

		public static readonly FontFamily[] FontFamilyArray = new FontFamily[]
		{
			FontFamilies.Arial,
			FontFamilies.ArialBlack,
			FontFamilies.Bookman,
			FontFamilies.ComicSansMS,
			FontFamilies.Courier,
			FontFamilies.CourierNew,
			FontFamilies.Garmond,
			FontFamilies.Georgia,
			FontFamilies.Helvetica,
			FontFamilies.Impact,
			FontFamilies.Palatino,
			FontFamilies.Times,
			FontFamilies.TimesNewRoman,
			FontFamilies.TrebuchetMS,
			FontFamilies.Verdana
		};

		public static BitmapImage ElectricRed { get; } = new BitmapImage(new System.Uri("Resources/ElectricRed.jpg", UriKind.Relative));

		public static readonly string[] StringMix =
		{
			LoremIpsum,
			"Hello",
			"Logic will get you from A to B. Imagination will take you everywhere."
		};

		public static readonly Tuple<Length, Length>[] SizesMix =
		{
			new Tuple<Length, Length>(new Length(240, Unit.Px), new Length(160, Unit.Px)),
			new Tuple<Length, Length>(new Length(480, Unit.Px), new Length(320, Unit.Px)),
			new Tuple<Length, Length>(new Length(120, Unit.Px), new Length(80, Unit.Px))
		};

		public static readonly Tuple<Length, Length>[] SizesMix2 =
		{
			new Tuple<Length, Length>(new Length(500, Unit.Px), new Length(300, Unit.Px)),
			new Tuple<Length, Length>(new Length(700, Unit.Px), new Length(400, Unit.Px)),
			new Tuple<Length, Length>(new Length(200, Unit.Px), new Length(300, Unit.Px))
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
				e_grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(new Length(1, Unit.Star)) });

			for (int row = 0; row < totRows; ++row)
				e_grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(new Length(1, Unit.Star)) });

			for (int col = 0; col < totCols; ++col)
				for (int row = 0; row < totRows; ++row)
				{
					var e_rect = new Rectangle()
					{
						Fill = cellBrush
					};

					e_grid.Children.Add(e_rect, new GridAnchor(col, row));
				}

			return e_grid;
		}

		/***********************************************************
			brushes
		***********************************************************/

		public static readonly SolidColorBrush[] SolidColorBrushes =
		{
			new SolidColorBrush(Colors.Aqua),
			new SolidColorBrush(Colors.Azure),
			new SolidColorBrush(Colors.Black),
			new SolidColorBrush(Colors.Blue),
			new SolidColorBrush(Colors.Cyan),
			new SolidColorBrush(Colors.DarkBlue),
			new SolidColorBrush(Colors.DarkGray),
			new SolidColorBrush(Colors.DarkMagenta),
			new SolidColorBrush(Colors.DarkRed),
			new SolidColorBrush(Colors.DarkSeaGreen),
			new SolidColorBrush(Colors.DarkSlateBlue),
			new SolidColorBrush(Colors.DarkViolet),
			new SolidColorBrush(Colors.DimGray),
			new SolidColorBrush(Colors.Gray),
			new SolidColorBrush(Colors.Green),
			new SolidColorBrush(Colors.Indigo),
			new SolidColorBrush(Colors.LightGray),
			new SolidColorBrush(Colors.LightBlue),
			new SolidColorBrush(Colors.Lime),
			new SolidColorBrush(Colors.Magenta),
			new SolidColorBrush(Colors.MidnightBlue),
			new SolidColorBrush(Colors.Orange),
			new SolidColorBrush(Colors.Red),
			new SolidColorBrush(Colors.SlateBlue),
			new SolidColorBrush(Colors.Transparent),
			new SolidColorBrush(Colors.Violet),
			new SolidColorBrush(Colors.White),
			new SolidColorBrush(Colors.Yellow)
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
				new Angle(AngleKind.ToRight),
				new GradientStopCollection()
					.Add(new GradientStop(Colors.BlueViolet, new Length(0.0, Unit.Percent)))
					.Add(new GradientStop(Colors.MidnightBlue, new Length(50.0, Unit.Percent)))
					.Add(new GradientStop(Colors.DarkTurquoise, new Length(100.0, Unit.Percent)))
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

		public static readonly GradientStopCollection GradientStops_Sunrise = new GradientStopCollection()
			.Add(new GradientStop(Colors.Red, new Length(0.0, Unit.Percent)))
			.Add(new GradientStop(Colors.Yellow, new Length(100.0, Unit.Percent)));

		public static readonly GradientStopCollection GradientStops_BlueHaze = new GradientStopCollection()
			.Add(new GradientStop(Colors.BlueViolet, new Length(0.0, Unit.Percent)))
			.Add(new GradientStop(Colors.MidnightBlue, new Length(50.0, Unit.Percent)))
			.Add(new GradientStop(Colors.DarkTurquoise, new Length(100.0, Unit.Percent)));

		public static readonly GradientStopCollection GradientStops_ShadedWhite = new GradientStopCollection()
            .Add(new GradientStop(Colors.White, new Length(0.0, Unit.Percent)))
            .Add(new GradientStop(Colors.White, new Length(85.0, Unit.Percent)))
            .Add(new GradientStop(Colors.Gray, new Length(100.0, Unit.Percent)));

		public static readonly GradientStopCollection GradientStops_TwilightZone = new GradientStopCollection()
			.Add(new GradientStop(Colors.MidnightBlue, new Length(0.0, Unit.Percent)))
			.Add(new GradientStop(Colors.Turquoise, new Length(100.0, Unit.Percent)));

		public static readonly GradientStopCollection GradientStops_Rainbow = new GradientStopCollection()
			.Add(new GradientStop(Colors.Red, new Length(0.0, Unit.Percent)))
			.Add(new GradientStop(Colors.Orange, new Length(20.0, Unit.Percent)))
			.Add(new GradientStop(Colors.Yellow, new Length(35.0, Unit.Percent)))
			.Add(new GradientStop(Colors.Green, new Length(50.0, Unit.Percent)))
			.Add(new GradientStop(Colors.Blue, new Length(65.0, Unit.Percent)))
			.Add(new GradientStop(Colors.Indigo, new Length(80.0, Unit.Percent)))
			.Add(new GradientStop(Colors.Violet, new Length(100.0, Unit.Percent)));

		public static readonly GradientStopCollection GradientStops_Chrome = new GradientStopCollection()
			.Add(new GradientStop(Color.FromRgb(255, 242, 242), new Length(0.0, Unit.Percent)))
			.Add(new GradientStop(Color.FromRgb(104,110, 100), new Length(40.0, Unit.Percent)))
			.Add(new GradientStop(Color.FromRgb(104, 100, 90), new Length(70.0, Unit.Percent)))
			.Add(new GradientStop(Color.FromRgb(54,0,0), new Length(100.0, Unit.Percent)));

		public static readonly GradientStopCollection GradientStops_Ruby = new GradientStopCollection()
			.Add(new GradientStop(Color.FromRgb(180, 0, 0), new Length(0.0, Unit.Percent)))
			.Add(new GradientStop(Color.FromRgb(92, 2, 2), new Length(50.0, Unit.Percent)))
			.Add(new GradientStop(Color.FromRgb(10, 3, 3), new Length(100.0, Unit.Percent)));

		public static readonly GradientStopCollection GradientStops_Sapphire = new GradientStopCollection()
			.Add(new GradientStop(Color.FromRgb(70, 143, 248), new Length(0.0, Unit.Percent)))
			.Add(new GradientStop(Color.FromRgb(0, 28, 197), new Length(50.0, Unit.Percent)))
			.Add(new GradientStop(Color.FromRgb(0, 9, 66), new Length(100.0, Unit.Percent)));

		public static readonly GradientStopCollection GradientStops_GrayFade = new GradientStopCollection()
			.Add(new GradientStop(Colors.DarkGray, new Length(0.0, Unit.Percent)))
			.Add(new GradientStop(Colors.Black, new Length(100.0, Unit.Percent)));

		public static readonly GradientStopCollection GradientStops_RicePaperFade = new GradientStopCollection()
			.Add(new GradientStop(Color.FromArgb(0.4, 255, 255, 255), new Length(0.0, Unit.Percent)))
			.Add(new GradientStop(Color.FromArgb(0.9, 255, 255, 255), new Length(100.0, Unit.Percent)));

		// Image Brushes
		public static readonly ImageBrush[] ImageBrushes =
		{
			new ImageBrush(Bitmaps.All[0].Bitmap),
			new ImageBrush(Bitmaps.All[1].Bitmap),
			new ImageBrush(Bitmaps.All[2].Bitmap),
			new ImageBrush(Bitmaps.All[3].Bitmap),
			new ImageBrush(Bitmaps.All[4].Bitmap),
			new ImageBrush(Bitmaps.All[5].Bitmap)
		};

		public static readonly Brush[] BrushesMix =
		{
			null,
			GetSolidColorBrush(Colors.Lime),
			GetSolidColorBrush(Colors.DarkMagenta),
			GetSolidColorBrush(Colors.White),
			GetSolidColorBrush(Colors.Transparent),
			LinearGradientBrushes[0],
			LinearGradientBrushes[1],
			RadialGradientBrushes[0],
			RadialGradientBrushes[1],
			ImageBrushes[2],
			ImageBrushes[3],
			ImageBrushes[5]
		};

		public static readonly CartoonModel[] Cartoons =
		{
			new CartoonModel(Bitmaps.TheFlintstones, "Hanna-Barbera", "1960"),
			new CartoonModel(Bitmaps.TheJetsons, "Hanna-Barbera", "1962"),
			new CartoonModel(Bitmaps.ScoobyDoo, "Hanna-Barbera", "1969"),
			new CartoonModel(Bitmaps.TheSimpsons, "Matt Groening", "1989"),
			new CartoonModel(Bitmaps.FamilyGuy, "Seth MacFarlane", "1999"),
			new CartoonModel(Bitmaps.BobsBurgers, "Loren Bouchard", "2011"),
			new CartoonModel(Bitmaps.Disenchantment, "Matt Groening", "2018")
		};

#if wait
		public static readonly object[] RandomItems =
		{
			Demo.LinearGradientBrushes.Rainbow.Brush,
			Cartoons[0],
			Demo.LinearGradientBrushes.Rainbow.Brush,
			People.All[0],
			Demo.LinearGradientBrushes.BlueHaze.Brush,
			People.All[7],
			Demo.SolidColorBrushes.AliceBlue.Brush,
			People.All[8],
			People.All[9],
			Demo.LinearGradientBrushes.Chrome.Brush,
			Cartoons[2],
			Demo.LinearGradientBrushes.Sapphire.Brush,
			Cartoons[4],
			Demo.LinearGradientBrushes.Ruby.Brush,
			People.All[3],
			People.All[5],
			Cartoons[1],
			People.All[10],
			Bitmaps.Sun.Bitmap,
			People.All[11],
			People.All[12],
			People.All[13],
			Bitmaps.LesardeLogo.Bitmap
		};
#endif

		public static ModelViewMatcher ItemsControlViewMatcher { get; } = new ModelViewMatcher();
		
		/*******************************************************************************
			$
		*******************************************************************************/

		static Common()
		{
			// Populate the general purpose ItemsControl view matcher
			ItemsControlViewMatcher.Add(typeof(Person), new Lesarde.Frogui.Controls.Primitives.ModelViewMatch(typeof(PersonView)));
			ItemsControlViewMatcher.Add(typeof(CartoonModel), new Lesarde.Frogui.Controls.Primitives.ModelViewMatch(typeof(CartoonView)));
			ItemsControlViewMatcher.Add(typeof(BrushInfo), new Lesarde.Frogui.Controls.Primitives.ModelViewMatch(typeof(BrushInfoView)));
			ItemsControlViewMatcher.Add(typeof(Bitmaps.BitmapInfo), new Lesarde.Frogui.Controls.Primitives.ModelViewMatch(typeof(BitmapInfoView)));
			ItemsControlViewMatcher.Add(typeof(string), new Lesarde.Frogui.Controls.Primitives.ModelViewMatch(typeof(StringView)));
		}


	}
}

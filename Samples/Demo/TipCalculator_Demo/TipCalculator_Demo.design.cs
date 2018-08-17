using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;

namespace Demo.TipCalculator
{
	/***************************************************************************************************
		TipCalculator_Demo class
	***************************************************************************************************/

	public partial class TipCalculator_Demo : Border
	{
		/***********************************************************
			constants
		***********************************************************/

		public static readonly FontSize
			LabelFontSize = FontSize.FromKind(FontSizeKind.Medium),
			InputFontSize = FontSize.FromKind(FontSizeKind.Large),
			TotalFontSize = FontSize.FromKind(FontSizeKind.XxLarge);

		public static readonly Brush
			LabelForeground = Common.GetSolidColorBrush(Colors.White),
			SecondaryLabelForeground = Common.GetSolidColorBrush(Colors.LightBlue);

		public static readonly FontWeight
			FontWeight = new FontWeight(FontWeightKind.Lighter);

		public static readonly FontFamily
			FontFamily = new FontFamily("helvetica");

		/***********************************************************
			elements
		***********************************************************/

		Flex
			e_flex;

		/*******************************************************************************
			InitializeComponent()
		*******************************************************************************/

		public void InitializeComponent()
		{
			Background = new SolidColorBrush(Color.FromRgb(116, 189, 223));
			HorizontalAlignment = Lesarde.Frogui.HorizontalAlignment.Stretch;
			Padding = new Thickness(new Length(40, Unit.Px));

			e_flex = new Flex()
			{
				HorizontalAlignment = Lesarde.Frogui.HorizontalAlignment.Stretch,
				VerticalAlignment = Lesarde.Frogui.VerticalAlignment.Stretch,
				Wrapping = FlexWrapping.Wrap
			};

			Child = e_flex;
		}


	}
}

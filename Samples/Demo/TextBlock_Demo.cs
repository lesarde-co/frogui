using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo
{
	/***************************************************************************************************
		TextBlock_Demo class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="TextBlock"/> element.
	/// </summary>
	public partial class TextBlock_Demo : WrappingFlex
    {
		public TextBlock_Demo() : base(331, 1901)
		{
			InitializeComponent();

			foreach (var text in Common.StringMix)
				foreach (var fontSize in Common.FontSizeMix)
					foreach (var fontFamily in Common.FontFamilyMix)
						foreach (var fontWeight in Common.FontWeightMix)
							foreach (var fontStyle in Common.FontStyleMix)
								foreach (var width in Common.WidthMix)
									foreach (var fontStretch in Common.FontStretchMix)
										foreach (var foreground in Common.BrushesMix)
											if (! (foreground is ImageBrush || foreground is GradientBrush)) // TODO:This combo does not work
												foreach (var background in Common.BrushesMix)
													if (foreground != background && IsReady())
														AddExample(new TextBlock()
														{
															Margin = Common.Margin,
															Width = width,
															Text = text,
															FontSize = fontSize,
															FontFamily = fontFamily,
															FontWeight = fontWeight,
															FontStretch = fontStretch,
															Foreground = foreground,
															Background = background,
														});
		}
	}
}

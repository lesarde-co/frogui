using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo.Border_Class
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="Border"/> control.
	/// </summary>
	public class View : WrappingFlex
    {
		public View() : base(47, 351)
		{
			// TODO: Show background clip options

			foreach (var size in Common.SizesMix)
				foreach (var thickness in Common.ThicknessMix)
					foreach (var cornerRadius in Common.CornerRadiusMix)
						foreach (var borderBrush in Common.BrushesMix)
							foreach (var background in Common.BrushesMix)
								if (borderBrush != background)
									foreach (var borderPattern in Common.BorderPatterns)
										if (IsReady())
										{
											var border = new Border()
											{
												Margin = Common.Margin,
												Width = size.Item1,
												Height = size.Item2,
												BorderThickness = thickness,
												CornerRadius = cornerRadius,
												BorderBrush = borderBrush,
												Background = background,
												BorderPattern = borderPattern
											};

											// Every so often add text content to the Border control...
											if (Current % (Skip * 3) == 0)
											{
												border.Child = new TextBlock() { Text = Common.LoremIpsum, Foreground = Common.GetSolidColorBrush(Colors.White) };

												// Have the border clip the text, but every so often don't clip
												border.ClipChildAtBorder = (Current % (Skip * 10) != 0);
											}

											AddExample(border);
										}
		}
	}
}

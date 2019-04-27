using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;

namespace Demo.TextBox_Class
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="TextBox"/> element.
	/// </summary>
	public partial class View : WrappingFlex
    {
		public View() : base(23, 95)
		{
			foreach (var size in Common.SizesMix)
				foreach (var childSize in Common.SizesMix2)
					foreach (ScrollBarVisibility horizontalScrollBarVisibility in Enum.GetValues(typeof(ScrollBarVisibility)))
						foreach (ScrollBarVisibility verticalScrollBarVisibility in Enum.GetValues(typeof(ScrollBarVisibility)))
							foreach (var text in Common.StringMix)
								foreach (var background in Common.BrushesMix)
									foreach (var foreground in Common.BrushesMix)
										if (!(foreground is ImageBrush || foreground is GradientBrush)) // TODO:This combo does not work
											if (foreground != background && IsReady())
											{
												var textBox = new TextBox()
												{
													Foreground = foreground,
													Background = background,
													Margin = Common.Margin,
													Width = size.Item1,
													Height = size.Item2,
													HorizontalScrollBarVisibility = horizontalScrollBarVisibility,
													VerticalScrollBarVisibility = verticalScrollBarVisibility,
													Text = text,
												};

												AddExample(textBox);
											}
		}
	}
}

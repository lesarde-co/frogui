using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;

namespace Demo.ScrollViewer_Class
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="ScrollViewer"/> element.
	/// </summary>
	public partial class View : WrappingFlex
    {
		public View() : base(5, 23)
		{
			foreach (var size in Common.SizesMix)
				foreach (var childSize in Common.SizesMix2)
					foreach (ScrollBarVisibility horizontalScrollBarVisibility in Enum.GetValues(typeof(ScrollBarVisibility)))
						foreach (ScrollBarVisibility verticalScrollBarVisibility in Enum.GetValues(typeof(ScrollBarVisibility)))
							for (var curChild = 0; curChild < 6; ++curChild)
								if (IsReady())
								{
									var scrollViewer = new ScrollViewer()
									{
										Margin = Common.Margin,
										Width = size.Item1,
										Height = size.Item2,
										HorizontalScrollBarVisibility = horizontalScrollBarVisibility,
										VerticalScrollBarVisibility = verticalScrollBarVisibility,
									};

									switch (curChild)
									{
										case 0:
											scrollViewer.Child = new TextBlock() { Text = Common.StringMix[0], Foreground = Common.GetSolidColorBrush(Colors.White), Width = childSize.Item1, Height = childSize.Item2 };
											break;
										case 1:
											scrollViewer.Child = new TextBlock() { Text = Common.StringMix[1], Foreground = Common.GetSolidColorBrush(Colors.Orange), Width = childSize.Item1, Height = childSize.Item2 };
											break;
										case 2:
											scrollViewer.Child = new TextBlock() { Text = Common.StringMix[2], Foreground = Common.GetSolidColorBrush(Colors.Yellow), Width = childSize.Item1, Height = childSize.Item2 };
											break;
										case 3:
											scrollViewer.Child = new Image() { Source = Common.Bitmaps[0], Width = childSize.Item1, Height = childSize.Item2 };
											break;
										case 4:
											scrollViewer.Child = new Image() { Source = Common.Bitmaps[1], Width = childSize.Item1, Height = childSize.Item2 };
											break;
										case 5:
											scrollViewer.Child = new Image() { Source = Common.Bitmaps[2], Width = childSize.Item1, Height = childSize.Item2 };
											break;
									}

									AddExample(scrollViewer);
								}
		}
	}
}

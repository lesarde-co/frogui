using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;

namespace Demo
{
	/***************************************************************************************************
		LayoutAlignment_Demo class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the use of <see cref="FrameworkElement.HorizontalAlignment"/>
	/// and <see cref="FrameworkElement.VerticalAlignment"/> properties.
	/// </summary>
	public partial class LayoutAlignment_Demo : Grid
	{
		public LayoutAlignment_Demo()
		{
			InitializeComponent();

			var horzEnumValues = Enum.GetValues(typeof(HorizontalAlignment));
			var vertEnumValues = Enum.GetValues(typeof(VerticalAlignment));

			Common.PrepareDemoGrid(this, horzEnumValues.Length, vertEnumValues.Length, Common.GetSolidColorBrush(Colors.Blue), Common.GetSolidColorBrush(Colors.DarkSeaGreen));

			var textFrgdBrush = Common.GetSolidColorBrush(Colors.White);
			var textBkgdBrush = Common.GetSolidColorBrush(Colors.DarkViolet);

			var padding = new Thickness(new Length(5.0, Unit.Px));

			int col = 0, row = 0;

			foreach (HorizontalAlignment horz in horzEnumValues)
			{
				foreach (VerticalAlignment vert in vertEnumValues)
				{
					var anchor = new Grid.Anchor(col, row);

					var e_textBlock = new TextBlock()
					{
						Text = $"{horz}, {vert}",
						Foreground = textFrgdBrush,
						Background = textBkgdBrush,
						HorizontalAlignment = horz,
						VerticalAlignment = vert,
						Padding = padding
					};

					this.Children.Add(e_textBlock, anchor);

					++row;
				}

				row = 0;
				++col;
			}

		}
	}
}

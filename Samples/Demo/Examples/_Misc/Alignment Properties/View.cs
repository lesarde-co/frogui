using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;

namespace Demo.Example_Alignment_Properties
{
	/***************************************************************************************************
		LayoutAlignment_Demo class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the use of <see cref="FrameworkElement.HorizontalAlignment"/>
	/// and <see cref="FrameworkElement.VerticalAlignment"/> properties.
	/// </summary>
	public partial class View : Grid, IExampleView
	{
		public View()
		{
			var bkgdBrush = new ImageBrush(Common.ElectricRed);

			var horzEnumValues = Enum.GetValues(typeof(HorizontalAlignment));
			var vertEnumValues = Enum.GetValues(typeof(VerticalAlignment));

			Common.PrepareDemoGrid(this, horzEnumValues.Length, vertEnumValues.Length, SolidColorBrushes.Blue.Brush, bkgdBrush);

			//var textFrgdBrush = SolidColorBrushes.White.Brush;
			//var textBkgdBrush = Common.GetSolidColorBrush(Colors.DarkViolet);

			var padding = new Thickness(new Length(5.0, Unit.Px));

			int col = 0, row = 0;

			foreach (HorizontalAlignment horz in horzEnumValues)
			{
				foreach (VerticalAlignment vert in vertEnumValues)
				{
					
					var anchor = new GridAnchor(col, row);

					var e_textBlock = new TextBlock()
					{
						//Offset = new Thickness(new Length(10, Unit.Px)),
						Text = $"{horz}, {vert}",
						Foreground = SolidColorBrushes.White.Brush,
						Background = SolidColorBrushes.DarkMagenta.Brush,
						Padding = padding,
						HorizontalAlignment = horz,
						VerticalAlignment = vert
					};

					this.Children.Add(e_textBlock, anchor);

					++row;
				}

				row = 0;
				++col;
			}

		}

		Element IExampleView.MainElement => this;
	}
}

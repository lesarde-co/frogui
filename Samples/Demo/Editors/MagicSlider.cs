using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;
using System;

namespace Demo
{
	/***************************************************************************************************
		MagicSlider class
	***************************************************************************************************/

	public abstract class MagicSlider : Slider
	{
		internal class DefaultPreviewView : TextBlock
		{
			public DefaultPreviewView()
			{
				Width = new Length(50, Unit.Px);

				// When the data context changes update the Text property
				AddPropertyChangedListener(Element.DataContextProperty, v =>
					{
						Text = (v is decimal) ? ((decimal)v).ToString("0.00") : (null == v) ? String.Empty : v.ToString();
					});
			}
		}
		
		/*******************************************************************************
			$
		*******************************************************************************/

		public MagicSlider()
		{
			Focusable = false;

			var ThumbButtonSize = new Length(11, Unit.Px);

			this.Minimum = 0m;
			this.Maximum = 10m;
			this.Height = new Length(20, Unit.Px);
			this.Width = new Length(300, Unit.Px);
			this.Orientation = Orientation.Horizontal;
			this.SmallChange = 0.25m;
			this.LargeChange = 1m;
			this.Value = 0m;
			this.EdgeDesign = TrackEdgeDesign.Square;
			this.TrackBreadth = Length.InPixels(1);
			this.TrackBackground = SolidColorBrushes.White.Brush;
			this.ThumbButtonLength = ThumbButtonSize;
			this.ThumbButtonBreadth = ThumbButtonSize;
		}
	}
}

using Lesarde;
using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo
{
	public partial class BrushInfoView : TextBlock
	{
		public BrushInfoView()
		{
			InitializeComponent();

			AddPropertyChangedListener(TextBlock.BackgroundProperty, BackgroundChanged, true);
		}

		internal void BackgroundChanged(Brush brush)
		{
			LesardeDebug.AssertValued(brush);

			if (brush is SolidColorBrush solidColorBrush)
			{
				TextShadowColor = null;
				TextShadowBlur = Length.ZeroPx;
				TextShadowHorizontalOffset = Length.ZeroPx;
				TextShadowVerticalOffset = Length.ZeroPx;

				if ((solidColorBrush.Color.R.Intensity + solidColorBrush.Color.G.Intensity + solidColorBrush.Color.B.Intensity) / 3 >= 0x80)
					this.Foreground = SolidColorBrushes.Black.Brush;
				else
					this.Foreground = SolidColorBrushes.White.Brush;
			}
			else
			{
				Foreground = SolidColorBrushes.White.Brush;
				TextShadowColor = (SolidColorBrush)SolidColorBrushes.Black.Brush;
				TextShadowBlur = Length.InPixels(1);
				TextShadowHorizontalOffset = Length.InPixels(1);
				TextShadowVerticalOffset = Length.InPixels(1);
			}
			//if (brush is SolidColorBrush solidColorBrush && ((solidColorBrush.Color.R.Intensity + solidColorBrush.Color.G.Intensity + solidColorBrush.Color.B.Intensity) / 3 >= 0x80))
			//	this.Foreground = SolidColorBrushes.Black.Brush;
			//else
			//	this.Foreground = SolidColorBrushes.White.Brush;

		}
	}
}

using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;

namespace Demo
{
	internal class StringView : TextBlock
	{
		public StringView()
		{
			Foreground = SolidColorBrushes.White.Brush;
			FontSize = Lesarde.Frogui.Media.FontSize.FromKind(Lesarde.Frogui.Media.FontSizeKind.Large);
			FontWeight = Lesarde.Frogui.Media.FontWeight.FromKind(Lesarde.Frogui.Media.FontWeightKind.Normal);
			TextShadowColor = (SolidColorBrush)SolidColorBrushes.Black.Brush;
			TextShadowBlur = Length.InPixels(3);
			TextShadowHorizontalOffset = Length.InPixels(1);
			TextShadowVerticalOffset = Length.InPixels(1);
			VerticalAlignment = VerticalAlignment.Center;
			Padding = Thickness.InPixels(2);
			Margin = new Thickness(Length.InPixels(4), Length.InPixels(0), Length.InPixels(4), Length.InPixels(0));
			// When the data context changes update the Text property
			AddPropertyChangedListener(Element.DataContextProperty, v => { Text = v?.ToString(); });
		}
	}
}

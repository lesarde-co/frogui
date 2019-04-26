using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;
using Lesarde.Frogui.Media;
using Lesarde.Frogui.Media.Effects;

namespace Demo
{
	/***************************************************************************************************
		GraphicsEffectEditor class
	***************************************************************************************************/

	public class GraphicsEffectEditor : Form, IPropertyEditor
	{
		/***********************************************************
			effect editors
		***********************************************************/

		EffectEditor<SolidColorBrushEditor> E_BoxShadow { get; set; }
		EffectEditor<LengthEditor> E_Blur { get; set; }
		EffectEditor<DoubleSlider> E_Brightness { get; set; }
		EffectEditor<DoubleSlider> E_Contrast { get; set; }
		EffectEditor<LengthEditor> E_DropShadow { get; set; }
		EffectEditor<DoubleSlider> E_Grayscale { get; set; }
		EffectEditor<AngleEditor> E_HueRotate { get; set; }
		EffectEditor<DoubleSlider> E_Invert { get; set; }
		EffectEditor<DoubleSlider> E_Opacity { get; set; }
		EffectEditor<DoubleSlider> E_Saturate { get; set; }
		EffectEditor<DoubleSlider> E_Sepia { get; set; }

		/***********************************************************
			CombinedEffect property
		***********************************************************/

		public static DependencyProperty<GraphicsEffect, GraphicsEffectEditor> ValueProperty { get; } = DependencyProperty<GraphicsEffect, GraphicsEffectEditor>
			.Register()
			.Changed((d, e) =>
			{
			});

		public GraphicsEffect Value
		{
			get => GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		public CombinedEffect CombinedEffect => (CombinedEffect)Value;

		/*******************************************************************************
			$
		*******************************************************************************/

		public GraphicsEffectEditor()
		{
			this.Padding = new Thickness(Length.InPixels(8));
		}

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			SetBinding(ValueProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });

			var combinedEffect = new CombinedEffect();

			var element = (Element)sourceObject;
			element.GraphicsEffect = combinedEffect;

			E_BoxShadow = new EffectEditor<SolidColorBrushEditor>(this, "Box Shadow (Color)", new BoxShadowEffect() { OffsetX = Length.InPixels(13), OffsetY = Length.InPixels(13), Blur = Length.InPixels(7), Spread = Length.InPixels(5) }, BoxShadowEffect.ColorProperty);
			E_Blur = new EffectEditor<LengthEditor>(this, "Blur", new BlurEffect(), BlurEffect.RadiusProperty);
			E_Brightness = new EffectEditor<DoubleSlider>(this, "Brightness", new BrightnessEffect(), BrightnessEffect.AmountProperty);
			E_Contrast = new EffectEditor<DoubleSlider>(this, "Contrast", new ContrastEffect(), ContrastEffect.AmountProperty);
			E_DropShadow = new EffectEditor<LengthEditor>(this, "Drop Shadow (Blur)", new DropShadowEffect() { Color = (SolidColorBrush)SolidColorBrushes.Black.Brush, OffsetX = Length.InPixels(10), OffsetY = Length.InPixels(10) }, DropShadowEffect.BlurProperty);
			E_Grayscale = new EffectEditor<DoubleSlider>(this, "Grayscale", new GrayscaleEffect(), GrayscaleEffect.AmountProperty);
			E_HueRotate = new EffectEditor<AngleEditor>(this, "Hue Rotate", new HueRotateEffect(), HueRotateEffect.AngleProperty);
			E_Invert = new EffectEditor<DoubleSlider>(this, "Invert", new InvertEffect(), InvertEffect.AmountProperty);
			E_Opacity = new EffectEditor<DoubleSlider>(this, "Opacity", new OpacityEffect(), OpacityEffect.AmountProperty);
			E_Saturate = new EffectEditor<DoubleSlider>(this, "Saturate", new SaturateEffect(), SaturateEffect.AmountProperty);
			E_Sepia = new EffectEditor<DoubleSlider>(this, "Sepia", new SepiaEffect(), SepiaEffect.AmountProperty);
		}
	}
}

using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;
using Lesarde.Frogui.Media;

namespace Demo
{
	public class BrushEditor : Border, IPropertyEditor
	{
		public BrushEditor()
		{
			BorderThickness = Thickness.InPixels(1);
			BorderBrush = SolidColorBrushes.Gray.Brush;
			MinWidth = Length.InPixels(100);
			Height = Length.InPixels(40);
			CornerRadius = CornerRadius.InPixels(3);

			IsHitTestVisible = true;

			PointerClick += BrushZoomer_PointerClick;
		}

		void BrushZoomer_PointerClick(object sender, Lesarde.Frogui.Input.PointerEventArgs e)
		{
			var editor = MainWindow.Me.e_brushPicker as IPropertyEditor;

			if (null != editor)
				editor.BindToSourceProperty(this, BackgroundProperty);
		}

		public Brush Brush
		{
			get => Background;
			set => Background = value;
		}

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(BackgroundProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
	}
}

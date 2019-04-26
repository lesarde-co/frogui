using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	public class BooleanEditor : CheckBox, IPropertyEditor
	{
		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			SetBinding(CheckBox.IsCheckedProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		}

		public BooleanEditor()
		{
			BorderThickness = Length.ZeroPx;
			CornerRadius = CornerRadius.InPixels(2);
		}
	}
}

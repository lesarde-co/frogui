using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Data;

namespace Demo
{
	/***************************************************************************************************
		DoubleSlider class
	***************************************************************************************************/

	public class DoubleSlider : MagicSlider, IPropertyEditor
	{
		public override bool TranslateToUserValue1(decimal value, out object newValue)
		{
			newValue = (double)value;
			return true;
		}

		public override void TranslateFromUserValue1(object userValue1, out decimal newValue)
		{
			newValue = (decimal)(double)userValue1;
		}

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			SetBinding(UserValue1Property, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		}

		public DoubleSlider()
		{
			PreviewView = new DefaultPreviewView();
		}
	}
}

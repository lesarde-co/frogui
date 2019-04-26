using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Data;

namespace Demo
{
	//public class PercentEditor : DoubleSlider, IPropertyEditor
	public class PercentEditor : DoubleSlider
	{
		//void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		//{
		//	SetBinding(UserValue1Property, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		//}

		public PercentEditor()
		{
			SmallChange = 0.01m;
			LargeChange = SmallChange;
			Maximum = 1.0m;
		}
	}
}

using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	public class DoubleEditor : NumericEdit, IPropertyEditor
	{
		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		//public override void BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(NumberProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(NumberDoubleProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });

		public DoubleEditor()
		{
			TypeFilter = NumericTypeFilter.Double;
		}
	}
}

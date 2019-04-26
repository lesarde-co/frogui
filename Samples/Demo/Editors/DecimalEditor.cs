using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	public class DecimalEditor : NumericEdit, IPropertyEditor
	{
		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(NumberDecimalProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });

		public DecimalEditor()
		{
			TypeFilter = NumericTypeFilter.Decimal;
		}

	}
}

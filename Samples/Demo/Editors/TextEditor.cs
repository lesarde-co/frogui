using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	/***************************************************************************************************
		TextEditor class
	***************************************************************************************************/
	/// <summary>
	/// Edits a <see cref="System.String"/> property.
	/// </summary>
	public class TextEditor : TextBox, IPropertyEditor
	{
		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		public void BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(TextProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
	}
}

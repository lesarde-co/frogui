using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	/***************************************************************************************************
		CheckedEditorPart class
	***************************************************************************************************/

	//public class CheckedEditorPart<EDITOR> : Grid, IPropertyEditor where EDITOR : Element, IPropertyEditor, new()
	public class CheckedEditorPart<EDITOR> : Grid where EDITOR : Element, IPropertyEditor, new()
	{
		/***********************************************************
			element properties
		***********************************************************/

		public CheckBox E_checkBox { get; } = new CheckBox() { Focusable = false, BorderThickness = Length.ZeroPx, CornerRadius = CornerRadius.InPixels(2) };

		protected EDITOR E_editor { get; } = new EDITOR() { Focusable = false,  Margin = new Thickness(new Length(8, Unit.Px), Length.ZeroPx, Length.ZeroPx, Length.ZeroPx) };

		/*******************************************************************************
			$
		*******************************************************************************/

		public CheckedEditorPart()
		{
			ColumnCount = 2;
			Children.Add(E_checkBox, new GridAnchor(0, 0));
			Children.Add(E_editor, new GridAnchor(1, 0));

			E_checkBox.AddPropertyChangedListener(CheckBox.IsCheckedProperty, ValuedChanged_IsChecked);

			//E_slider.OnValueChanged(MagicSlider.ValueProperty, (value) =>
			//{
			//});

		}

		/*******************************************************************************
			ValuedChanged_IsChecked()
		*******************************************************************************/

		internal virtual void ValuedChanged_IsChecked(bool value)
		{
			E_editor.Visibility = (value) ? Visibility.Visible : Visibility.Collapsed;
		}

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		//void BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		//{
		//	E_editor.BindToSourceProperty(sourceObject, sourceProperty);
		//	//SetBinding(Slider.UserValue1Property, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });

		//	sourceObject.OnValueChanged(sourceProperty, Source_ValueChanged);
		//}

		//internal void Source_ValueChanged(object v)
		//{
		//	E_checkBox.IsChecked = null != v;
		//}
	}
}

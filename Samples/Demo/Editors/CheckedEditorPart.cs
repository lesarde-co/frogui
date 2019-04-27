using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	/***************************************************************************************************
		CheckedEditorPart class
	***************************************************************************************************/

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
		}

		/*******************************************************************************
			ValuedChanged_IsChecked()
		*******************************************************************************/

		internal virtual void ValuedChanged_IsChecked(bool value)
		{
			E_editor.Visibility = (value) ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}

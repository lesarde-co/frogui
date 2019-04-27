using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using System;

namespace Demo
{
	/***************************************************************************************************
		NullableSolidBrushColorEditor class
	***************************************************************************************************/

	public class NullableSolidBrushColorEditor : CheckedEditorPart<SolidColorBrushEditor>, IPropertyEditor
	{
		WeakReference<DependencyObject> WeakSourceObject { get; set; }
		DependencyObject SourceObject
		{
			get
			{
				WeakSourceObject.TryGetTarget(out var target);
				return target;
			}
		}

		DependencyProperty SourceProperty { get; set; }

		internal override void ValuedChanged_IsChecked(bool value)
		{
			base.ValuedChanged_IsChecked(value);

			if (null == WeakSourceObject)
				return;

			if (!value)
				SourceObject.SetValue(SourceProperty, null);
		}

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			WeakSourceObject = new WeakReference<DependencyObject>(sourceObject);
			SourceProperty = sourceProperty;

			((IPropertyEditor)E_editor).BindToSourceProperty(sourceObject, sourceProperty);

			sourceObject.AddPropertyChangedListener(sourceProperty, Source_ValueChanged);
		}

		internal void Source_ValueChanged(object v)
		{
			E_checkBox.IsChecked = null != v;
		}
	}
}

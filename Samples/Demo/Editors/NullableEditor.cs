//using Lesarde.Frogui;
//using Lesarde.Frogui.ComponentModel;
//using System;

//namespace Demo
//{
//	/***************************************************************************************************
//		NullableEditor class
//	***************************************************************************************************/

//	public class NullableEditor<EDITOR> : CheckedEditorPart<EDITOR>, IPropertyEditor where EDITOR : Element, IPropertyEditor, new()
//	{
//		WeakReference<DependencyObject> WeakSourceObject { get; set; }
//		DependencyObject SourceObject
//		{
//			get
//			{
//				WeakSourceObject.TryGetTarget(out var target);
//				return target;
//			}
//		}

//		DependencyProperty SourceProperty { get; set; }

//		internal override void ValuedChanged_IsChecked(bool? value)
//		{
//			if (null == WeakSourceObject)
//				return;

//			if (!value.Value)
//				SourceObject.SetValue(SourceProperty, null);
//			else
//				SourceObject.SetValue(SourceProperty, );
//		}

//		/*******************************************************************************
//			BindToSourceProperty()
//		*******************************************************************************/

//		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
//		{
//			WeakSourceObject = new WeakReference<DependencyObject>(sourceObject);
//			SourceProperty = sourceProperty;

//			E_editor.BindToSourceProperty(sourceObject, sourceProperty);
//			//SetBinding(Slider.UserValue1Property, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });

//			sourceObject.OnValueChanged(sourceProperty, Source_ValueChanged);
//		}

//		internal void Source_ValueChanged(object v)
//		{
//			E_checkBox.IsChecked = null != v;
//		}
//	}
//}

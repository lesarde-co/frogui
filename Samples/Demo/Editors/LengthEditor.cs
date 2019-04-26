using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	public class LengthEditor : LengthEditorBase
	{
		/***********************************************************
			Value property
		***********************************************************/

		public static DependencyProperty<Length, LengthEditor> ValueProperty { get; } = DependencyProperty<Length, LengthEditor>
			.Register()
			.Changed((d, e) =>
			{
				if (!d.AvoidRecursion)
					d.NumberDouble = e.NewValue.Size;
			});

		public Length Value
		{
			get => GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public LengthEditor()
		{
			AddPropertyChangedListener(NumericEdit.NumberDoubleProperty, ValueChanged_Number);
		}

		/*******************************************************************************
			ValueChanged_Number()
		*******************************************************************************/

		void ValueChanged_Number(double number)
		{
			AvoidRecursion = true;
			Value = Length.InPixels(number);
			AvoidRecursion = false;
		}

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		public override void BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(ValueProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
	}
}

using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;
using Lesarde.Frogui.Media;

namespace Demo
{
	public class AngleEditor : LengthEditorBase
	{
		/***********************************************************
			Value property
		***********************************************************/

		public static DependencyProperty<Angle, AngleEditor> ValueProperty { get; } = DependencyProperty<Angle, AngleEditor>
			.Register()
			.Changed((d, e) =>
			{
				if (!d.AvoidRecursion)
					d.NumberDouble = e.NewValue.Size;
			});

		public Angle Value
		{
			get => GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public AngleEditor()
		{
			AddPropertyChangedListener(NumericEdit.NumberDoubleProperty, ValueChanged_Number);
		}

		/*******************************************************************************
			ValueChanged_Number()
		*******************************************************************************/

		void ValueChanged_Number(double number)
		{
			AvoidRecursion = true;
			Value = new Angle(number, AngleKind.Deg);
			AvoidRecursion = false;
		}

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		public override void BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(ValueProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
	}
}

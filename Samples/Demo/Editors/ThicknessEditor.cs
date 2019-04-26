using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	public class ThicknessEditor : LengthEditorBase
	{
		/***********************************************************
			Value property
		***********************************************************/

		public static DependencyProperty<Thickness, ThicknessEditor> ValueProperty { get; } = DependencyProperty<Thickness, ThicknessEditor>
			.Register()
			.Changed((d, e) =>
			{
				if (!d.AvoidRecursion)
					d.NumberDouble = e.NewValue.Left.Size;
			});

		public Thickness Value
		{
			get => GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public ThicknessEditor()
		{
			AddPropertyChangedListener(NumericEdit.NumberDoubleProperty, ValueChanged_Number);
		}

		/*******************************************************************************
			ValueChanged_Number()
		*******************************************************************************/

		void ValueChanged_Number(double number) => Value = new Thickness(Length.InPixels(number));

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		public override void BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(ValueProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
	}
}

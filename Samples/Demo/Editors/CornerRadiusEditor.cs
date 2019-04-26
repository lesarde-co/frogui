using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	public class CornerRadiusEditor : LengthEditorBase
	{
		/***********************************************************
			Value property
		***********************************************************/

		public static DependencyProperty<CornerRadius, CornerRadiusEditor> ValueProperty { get; } = DependencyProperty<CornerRadius, CornerRadiusEditor>
			.Register()
			.Changed((d, e) =>
			{
				if (!d.AvoidRecursion)
					d.NumberDouble = e.NewValue.TopLeft.Size;
			});

		public CornerRadius Value
		{
			get => GetValue(ValueProperty);
			set => SetValue(ValueProperty, value);
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public CornerRadiusEditor()
		{
			AddPropertyChangedListener(NumericEdit.NumberDoubleProperty, NumberDoubleChanged);
		}

		/*******************************************************************************
			NumberDoubleChanged()
		*******************************************************************************/

		void NumberDoubleChanged(double number) => Value = new CornerRadius(Length.InPixels(number));

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		public override void BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty) => SetBinding(ValueProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
	}
}

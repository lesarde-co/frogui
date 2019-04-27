using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;

namespace Demo
{
	/***************************************************************************************************
		IntEditor class
	***************************************************************************************************/

	public class IntEditor : MagicSlider, IPropertyEditor
	{
		class MyPreviewView : TextBlock
		{
			public MyPreviewView()
			{
				Width = new Length(40, Unit.Px);

				// When the data context changes update the Text property
				AddPropertyChangedListener(Element.DataContextProperty, v =>
				{
					Text = (null == v) ? string.Empty : v.ToString();
				});
			}
		}

		public override bool TranslateToUserValue1(decimal value, out object newValue)
		{
			var i = (int)value;
			newValue = i;
			return true;
		}

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			SetBinding(UserValue1Property, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		}

		public virtual void IntChanged(int value) { }

		public override void TranslateFromUserValue1(object userValue1, out decimal newValue)
		{
			newValue = (decimal)(int)userValue1;
		}

		public IntEditor()
		{
			this.Maximum = 200m;

			PreviewSource = SliderPreviewSource.UserValue1;
			PreviewView = new MyPreviewView();

			this.SmallChange = 1m;
			this.LargeChange = 1m;

			AddPropertyChangedListener(Slider.UserValue1Property, ValueChanged_UserValue1);
		}

		public void ValueChanged_UserValue1(object value)
		{
			IntChanged((int)value);
		}
	}
}

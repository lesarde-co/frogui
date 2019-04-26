using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Data;

namespace Demo
{
	/***************************************************************************************************
		FontSizeSlider class
	***************************************************************************************************/

	public class FontSizeEditor : MagicSlider, IPropertyEditor
	{
		/*******************************************************************************
			$
		*******************************************************************************/

		public FontSizeEditor()
		{
			PreviewView = new DefaultPreviewView();
			Maximum = 72m;
		}

		/*******************************************************************************
			TranslateToUserValue1()
		*******************************************************************************/

		public override bool TranslateToUserValue1(decimal value, out object newValue)
		{
			newValue = Lesarde.Frogui.Media.FontSize.FromLength((double)value, Unit.Pt);
			return true;
		}

		public override void TranslateFromUserValue1(object userValue1, out decimal newValue)
		{
			newValue = (decimal)((Lesarde.Frogui.Media.FontSize)userValue1).SizeOrPercent;
		}

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			SetBinding(UserValue1Property, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		}

	}
}

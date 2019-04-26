using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;
using Lesarde.Frogui.Media;

namespace Demo
{
	/***************************************************************************************************
		FontFamilyEditor class

		https://websitesetup.org/web-safe-fonts-html-css/
	***************************************************************************************************/

	public class FontFamilyEditor : MagicSlider, IPropertyEditor
	{
		//readonly string[] FontFamilies = new string[]
		//{
		//"Arial",
		//"Arial Black",
		//"Bookman",
		//"Comic Sans MS",
		//"Courier",
		//"Courier New",
		//"Garamond",
		//"Georgia",
		//"Helvetica",
		//"Impact",
		//"Palatino",
		//"Times",
		//"Times New Roman",
		//"Trebuchet MS",
		//"Verdana"
		//};

		/***********************************************************
			FamilyName property
		***********************************************************/

		public override bool TranslateToUserValue1(decimal value, out object newValue)
		{
			newValue = Common.FontFamilyArray[(int)value];
			return true;
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public FontFamilyEditor()
		{
			PreviewSource = SliderPreviewSource.UserValue1;
			PreviewView = new DefaultPreviewView();
			
			this.SmallChange = 1.0m;
			this.LargeChange = 1.0m;
			this.Maximum = Common.FontFamilyArray.Length - 1;
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

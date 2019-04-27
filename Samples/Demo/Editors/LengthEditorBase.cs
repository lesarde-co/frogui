using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;

namespace Demo
{
	public abstract class LengthEditorBase : NumericEdit, IPropertyEditor
	{
		/***********************************************************
			AvoidRecursion property
		***********************************************************/

		protected bool AvoidRecursion { get; set; }

		/*******************************************************************************
			$
		*******************************************************************************/

		public LengthEditorBase()
		{
			TypeFilter = NumericTypeFilter.Double;

			Focusable = true;
			Height = Length.InPixels(20);
			VaryButtonDesign = VaryDesign.Triangle;
			VaryButtonLength = Length.InPixels(15);
			SmallChange = 1;
			LargeChange = 10;
		}

		public abstract void BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty);
	}
}

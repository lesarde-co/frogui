using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Data;
using Lesarde.Frogui.Media;

namespace Demo
{
	/***************************************************************************************************
		SolidColorBrushSlider class
	***************************************************************************************************/

	public class SolidColorBrushEditor : MagicSlider, IPropertyEditor
	{
		/***********************************************************
			MyPreviewView class
		***********************************************************/

		class MyPreviewView : Grid
		{
			TextBlock e_name { get; } = new TextBlock()
			{
				Foreground = SolidColorBrushes.LightGray.Brush,
				Width = new Length(175, Unit.Px)
			};

			Border e_color { get; } = new Border()
			{
				Margin = new Thickness(new Length(8, Unit.Px), Length.ZeroPx, new Length(8, Unit.Px), Length.ZeroPx),
				Width = new Length(50, Unit.Px),
				BorderBrush = SolidColorBrushes.DarkSlateGray.Brush,
				BorderThickness = new Thickness(new Length(1.5, Unit.Px)),
				CornerRadius = new CornerRadius(new Length(4, Unit.Px))
			};

			public MyPreviewView()
			{
				ColumnCount = 2;

				AddPropertyChangedListener(Element.DataContextProperty, v =>
					{
						if (v is BrushInfo colorInfo)
						{
							e_name.Text = colorInfo.Name;
							e_color.Background = colorInfo.Brush;
						}
					});

				this.Children.Add(e_color);
				this.Children.Add(e_name, new GridAnchor(1, 0));
			}
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public SolidColorBrushEditor()
		{
			PreviewSource = SliderPreviewSource.UserValue1;
			PreviewView = new MyPreviewView();

			this.SmallChange = 1.0m;
			this.LargeChange = 1.0m;
			this.Maximum = SolidColorBrushes.Singleton.All.Count - 1;
		}

		/*******************************************************************************
			TranslateToUserValue1()
		*******************************************************************************/

		public override bool TranslateToUserValue1(decimal value, out object newValue)
		{
			newValue = SolidColorBrushes.Singleton.All[(int)value];
			return true;
		}

		/*******************************************************************************
			TranslateToUserValue2()
		*******************************************************************************/

		public override bool TranslateToUserValue2(decimal value, out object newValue)
		{
			newValue = SolidColorBrushes.Singleton.All[(int)value].Brush;
			return true;
		}

		/*******************************************************************************
			TranslateFromUserValue1()
		*******************************************************************************/

		public override void TranslateFromUserValue1(object userValue1, out decimal newValue)
		{
			newValue = (decimal)SolidColorBrushes.Singleton.All.IndexOf((BrushInfo)userValue1);
		}

		/*******************************************************************************
			TranslateFromUserValue2()
		*******************************************************************************/

		public override void TranslateFromUserValue2(object userValue2, out decimal newValue)
		{
			newValue = (decimal)SolidColorBrushes.Singleton.IndexOf((Brush)userValue2);
			if (-1 == newValue)
				newValue = 0;
		}

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			SetBinding(UserValue2Property, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		}

	}

}

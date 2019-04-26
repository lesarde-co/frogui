using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Media;
using System;
using System.Collections.Generic;

namespace Demo
{
	/***************************************************************************************************
		BrushSlider class
	***************************************************************************************************/

	public class BrushSlider : MagicSlider
	{
		/***********************************************************
			MyPreviewView class
		***********************************************************/

		class MyPreviewView : Grid
		{
			TextBlock e_name { get; } = new TextBlock()
			{
				Foreground = SolidColorBrushes.LightGray.Brush,
				Width = new Length(75, Unit.Px)
			};

			Border e_color { get; } = new Border()
			{
				//Margin = new Thickness(new Length(8, Unit.Px), Length.ZeroPx, new Length(8, Unit.Px), Length.ZeroPx),
				Width = new Length(40, Unit.Px),
				Height = new Length(20, Unit.Px),
				BorderBrush = SolidColorBrushes.DarkSlateGray.Brush,
				BorderThickness = new Thickness(new Length(0.5, Unit.Px)),
				CornerRadius = new CornerRadius(new Length(4, Unit.Px))
			};

			public MyPreviewView()
			{
				ColumnCount = 2;

				AddPropertyChangedListener(Element.DataContextProperty, v =>
					//.Subscribe(v =>
					{
						if (v is BrushInfo colorInfo)
						{
							//var colorInfo = SolidColorBrushes.All[(int)v];

							e_name.Text = colorInfo.Name;
							e_color.Background = colorInfo.Brush;
						}
					});

				this.Children.Add(e_color);
				this.Children.Add(e_name, new GridAnchor(1, 0));
			}
		}

		/***********************************************************
			Brush property
		***********************************************************/

		public static DependencyProperty<Brush, BrushSlider> BrushProperty { get; } = DependencyProperty<Brush, BrushSlider>
			.Register();

		public Brush Brush
		{
			get => GetValue(BrushProperty);
			set => SetValue(BrushProperty, value);
		}

		/***********************************************************
			Items property
		***********************************************************/

		public Brushes Items
		{
			get => items;

			set
			{
				this.items = value;
				if (null != value)
					this.Maximum = Items.All.Count - 1;
			}
		}

		Brushes items;

		public override bool TranslateToUserValue1(decimal value, out object newValue)
		{
			newValue = Items?.All[(int)value];
			return true;
		}

		public override bool TranslateToUserValue2(decimal value, out object newValue)
		{
			newValue = Items?.All[(int)value].Brush;
			return true;
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public BrushSlider()
		{
			PreviewSource = SliderPreviewSource.UserValue1;
			PreviewView = new MyPreviewView();
			
			this.SmallChange = 1.0m;
			this.LargeChange = 1.0m;
		}

		~BrushSlider()
		{

		}
	}

}

using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Controls.Primitives;
using System;

namespace Demo.Example_ScrollBar
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="CheckBox"/> class.
	/// </summary>
	public partial class View : Decorator, IExampleView
    {
		Length
			SbWidth = new Length(60, Unit.Px),
			SbHeight = new Length(700, Unit.Px);

		Element IExampleView.MainElement => e_scrollbar;

		void AddEnums(Selector selector, Type type, object selectedItem)
		{
			foreach (var cur in Enum.GetValues(type))
				selector.Items.Add(cur);
			selector.SelectedItem = selectedItem;
		}

		/*******************************************************************************
			$
		*******************************************************************************/

		public View()
		{
			InitializeComponent();

			//e_settingsForm.DataContext = e_scrollbar;

			//e_settingsForm.HorizontalAlignment = HorizontalAlignment.Left;

			//e_orientation.BindIt(e_scrollbar, ScrollBar.OrientationProperty);
			//e_arrowDesign.BindIt(e_scrollbar, ScrollBar.VaryButtonDesignProperty);
			//e_edgeDesign.BindIt(e_scrollbar, ScrollBar.EdgeDesignProperty);

			PrepareScrollbar();
		}

		/*******************************************************************************
			E_orientation_SelectionChanged()
		*******************************************************************************/

		void E_orientation_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//// Horizontal
			//if ((Orientation)e_orientation.SelectedValue == Orientation.Horizontal)
			//{
			//	e_scrollbar.Width = this.SbHeight;
			//	e_scrollbar.Height = this.SbWidth;
			//}
			//// Vertical
			//else
			//{
			//	e_scrollbar.Width = this.SbWidth;
			//	e_scrollbar.Height = this.SbHeight;
			//}
		}

		/*******************************************************************************
			PrepareScrollbar()
		*******************************************************************************/

		void PrepareScrollbar()
		{
			//e_scrollbar.DataContext = this;

			e_scrollbar.AddPropertyChangedListener(ScrollBar.OrientationProperty, v =>
				//.Subscribe(v =>
				{
					// Horizontal
					if (e_scrollbar.Orientation == Orientation.Horizontal)
					{
						e_scrollbar.Width = this.SbHeight;
						e_scrollbar.Height = this.SbWidth;
					}
					// Vertical
					else
					{
						e_scrollbar.Width = this.SbWidth;
						e_scrollbar.Height = this.SbHeight;
					}
				});

			e_scrollbar.SmallChange = 1.0m;
			e_scrollbar.LargeChange = 10.0m;
			e_scrollbar.Minimum = 1.0m;
			e_scrollbar.Maximum = 10.0m;
			e_scrollbar.Value = e_scrollbar.Minimum;
			e_scrollbar.ViewportSize = 20.0m;
			//e_scrollbar.EdgeDesign = ScrollBarEdgeDesign.Round;
			//e_scrollbar.VaryButtonLength = new Length(32, Unit.Px);
			//e_scrollbar.VaryDesign = VaryDesign.Triangle;
			//e_scrollbar.VaryDesign = VaryDesign.None;
//			e_scrollbar.BorderBrush = new SolidColorBrush(Colors.Red);
			e_scrollbar.Background = SolidColorBrushes.Black.Brush;
			e_scrollbar.VaryButtonFill = SolidColorBrushes.DarkRed.Brush;
			e_scrollbar.TrackBackground = SolidColorBrushes.DodgerBlue.Brush;
			e_scrollbar.ThumbBackground = SolidColorBrushes.Violet.Brush;
			//e_scrollbar.BorderThickness = new Length(6, Unit.Px);
			//e_scrollbar.Padding = new Thickness(new Length(8, Unit.Px));
			//e_scrollbar.TrackBorderThickness = new Length(4, Unit.Px);
			//e_scrollbar.ThumbBorderThickness = new Length(2, Unit.Px);
			e_scrollbar.ThumbBorderBrush = SolidColorBrushes.Navy.Brush;

			//e_scrollbar.SetBinding(ScrollBar.VaryButtonDesignProperty, new Binding(ListBox.SelectedItemProperty, e_arrowDesign));
			//e_scrollbar.SetBinding(ScrollBar.EdgeDesignProperty, new Binding(ListBox.SelectedItemProperty, e_edgeDesign));
			/*
			e_scrollbar.SetBinding(ScrollBar.PaddingProperty, new Binding(Slider.UserValue1Property, e_padding));
			e_scrollbar.SetBinding(ScrollBar.VaryButtonLengthProperty, new Binding(Slider.UserValue1Property, e_arrowButtonLength));
			e_scrollbar.SetBinding(ScrollBar.BorderThicknessProperty, new Binding(Slider.UserValue1Property, e_borderThickness));
			e_scrollbar.SetBinding(ScrollBar.TrackBorderThicknessProperty, new Binding(Slider.UserValue1Property, e_trackBorderThickness));
			e_scrollbar.SetBinding(ScrollBar.ThumbBorderThicknessProperty, new Binding(Slider.UserValue1Property, e_thumbBorderThickness));
            e_scrollbar.SetBinding(TrackBase.TrackShadowBlurProperty, new Binding(Slider.UserValue1Property, e_trackShadowBlur));
            e_scrollbar.SetBinding(TrackBase.TrackShadowSpreadProperty, new Binding(Slider.UserValue1Property, e_trackShadowSpread));

            e_scrollbar.SetBinding(ScrollBar.BorderBrushProperty, new Binding(BrushPicker.BrushProperty, e_borderBrush));
			e_scrollbar.SetBinding(ScrollBar.BackgroundProperty, new Binding(BrushPicker.BrushProperty, e_background));
			e_scrollbar.SetBinding(ScrollBar.TrackBorderBrushProperty, new Binding(BrushPicker.BrushProperty, e_trackBorderBrush));
			e_scrollbar.SetBinding(ScrollBar.TrackBackgroundProperty, new Binding(BrushPicker.BrushProperty, e_trackBackground));
			e_scrollbar.SetBinding(ScrollBar.ThumbBorderBrushProperty, new Binding(BrushPicker.BrushProperty, e_thumbBorderBrush));
			e_scrollbar.SetBinding(ScrollBar.ThumbBackgroundProperty, new Binding(BrushPicker.BrushProperty, e_thumbBackground));
			e_scrollbar.SetBinding(ScrollBar.ArrowBrushProperty, new Binding(BrushPicker.BrushProperty, e_arrowBrush));
			*/
		}
	}
}

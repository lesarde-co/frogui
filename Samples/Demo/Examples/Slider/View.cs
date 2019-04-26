using Lesarde.Frogui;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Controls.Primitives;
using System;

namespace Demo.Example_Slider
{
	/***************************************************************************************************
		View class
	***************************************************************************************************/
	/// <summary>
	/// Demonstrates the <see cref="CheckBox"/> class.
	/// </summary>
	public partial class View : Decorator, IExampleView
    {
//		Length
	//		SbWidth = new Length(60, Unit.Px),
		//	SbHeight = new Length(700, Unit.Px);

		Element IExampleView.MainElement => e_slider;

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

			PrepareSlider();
		}


		/*******************************************************************************
			PrepareSlider()
		*******************************************************************************/

		void PrepareSlider()
		{
			//e_slider.AddPropertyChangedListener(Slider.OrientationProperty, v =>
			//	//.Subscribe(v =>
			//	{
			//		// Horizontal
			//		if (e_slider.Orientation == Orientation.Horizontal)
			//		{
			//			e_slider.Width = this.SbHeight;
			//			e_slider.Height = this.SbWidth;
			//		}
			//		// Vertical
			//		else
			//		{
			//			e_slider.Width = this.SbWidth;
			//			e_slider.Height = this.SbHeight;
			//		}
			//	});

			//e_slider.SmallChange = 1.0m;
			//e_slider.LargeChange = 10.0m;
			//e_slider.Minimum = 1.0m;
			//e_slider.Maximum = 10.0m;
			//e_slider.Value = e_slider.Minimum;

			//e_slider.ViewportSize = 20.0m;
			//e_slider.Background = SolidColorBrushes.Black.Brush;
			//e_slider.VaryButtonFill = SolidColorBrushes.DarkRed.Brush;
			//e_slider.TrackBackground = SolidColorBrushes.DodgerBlue.Brush;
			//e_slider.ThumbBackground = SolidColorBrushes.Violet.Brush;
			//e_slider.ThumbBorderBrush = SolidColorBrushes.Navy.Brush;
		}
	}
}

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

			PrepareScrollbar();
		}

		/*******************************************************************************
			E_orientation_SelectionChanged()
		*******************************************************************************/

		void E_orientation_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		/*******************************************************************************
			PrepareScrollbar()
		*******************************************************************************/

		void PrepareScrollbar()
		{
			e_scrollbar.AddPropertyChangedListener(ScrollBar.OrientationProperty, v =>
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

			e_scrollbar.Background = SolidColorBrushes.Black.Brush;
			e_scrollbar.VaryButtonFill = SolidColorBrushes.DarkRed.Brush;
			e_scrollbar.TrackBackground = SolidColorBrushes.DodgerBlue.Brush;
			e_scrollbar.ThumbBackground = SolidColorBrushes.Violet.Brush;

			e_scrollbar.ThumbBorderBrush = SolidColorBrushes.Navy.Brush;
		}
	}
}

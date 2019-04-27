#if wait
using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Controls.Primitives;
using Lesarde.Frogui.Data;
using Lesarde.Frogui.Media;
using System.Collections.Generic;
using System.Diagnostics;

namespace Demo
{
	/***************************************************************************************************
		BrushPicker class
	***************************************************************************************************/

	public class BrushPicker : Border, IPropertyEditor
    {
		/***********************************************************
			VarietySelector class
		***********************************************************/

		public class VarietySelector : EnumImageEditor<BrushVariety>
		{
			protected override void Initialize()
			{
				this.ItemViewMatcher = new SingleModelViewMatcher(typeof(Pixy));

				base.Initialize();
			}

			protected override bool UseValue(BrushVariety value)
			{
				return Varieties.HasFlag(value);
			}

			BrushVariety Varieties { get; set; }
		}

		/***********************************************************
			Last used brush variables
		***********************************************************/

		BrushInfo
			lastSolidBrushInfo,
			lastLinearGradientBrushInfo,
			lastRadialGradientBrushInfo,
			lastImageBrushInfo;

		/***********************************************************
			element properties
		***********************************************************/

		static readonly Length MARGIN = Length.InPixels(8);

		Grid E_Grid { get; } = new Grid() { Margin = Thickness.InPixels(8) };

		VarietySelector E_varietySelector { get; } = new VarietySelector() { Margin = new Thickness(Length.ZeroPx, Length.ZeroPx, MARGIN, Length.ZeroPx), Width = Length.InPixels(260) };

		Droplist E_droplist { get; } = new Droplist() { Margin = new Thickness(Length.ZeroPx, MARGIN, MARGIN, Length.ZeroPx), Width = Length.InPixels(260) };

		Border E_preview { get; } = new Border() { BorderBrush = SolidColorBrushes.DarkGray.Brush, BorderThickness = Thickness.InPixels(1), MinWidth = Length.InPixels(120) };

		/***********************************************************
			AvoidRecursion property
		***********************************************************/

		bool AvoidRecursion { get; set; }

		/***********************************************************
			Brush property
		***********************************************************/

		public static DependencyProperty<Brush, BrushPicker> BrushProperty { get; } = DependencyProperty<Brush, BrushPicker>
			.Register()
			.Changed((me, e) => me.BrushChanged(e.OldValue, e.NewValue));

		public Brush Brush
		{
			get => GetValue(BrushProperty);
			set
			{
				AvoidRecursion = true;
				SetValue(BrushProperty, value);
				AvoidRecursion = false;
			}
		}

		/***********************************************************
			Variety property
		***********************************************************/

		BrushVariety Variety => (BrushVariety)((Segment)E_varietySelector.SelectedItem).Value;

		/***********************************************************
			Brushes property
		***********************************************************/

		//Brushes Brushes => (Brushes)E_slider.Items;

		/*******************************************************************************
			$
		*******************************************************************************/

		public BrushPicker()
		{
			this.BorderThickness = Thickness.InPixels(1);
			this.BorderBrush = SolidColorBrushes.Gray.Brush;

			this.Child = E_Grid;

			E_Grid.ColumnCount = 2;
			E_Grid.RowCount = 2;

			E_Grid.Children.Add(E_varietySelector, new GridAnchor(0, 0));
			E_Grid.Children.Add(E_droplist, new GridAnchor(0, 1));
			E_Grid.Children.Add(E_preview, new GridAnchor(1, 0, 1, 2));
			
			E_varietySelector.SelectedItem = E_varietySelector.Items[0];
			E_varietySelector.AddPropertyChangedListener(Selector.SelectedValueProperty, VarietyChanged);

			E_droplist.ItemViewMatcher = new SingleModelViewMatcher(typeof(BrushInfoView));
			E_droplist.AddPropertyChangedListener(Droplist.SelectedItemProperty, DroplistSelectedItemChanged);

			E_preview.SetBinding(Border.BackgroundProperty, new Binding(BrushProperty, this));
		}

		/*******************************************************************************
			DroplistSelectedItemChanged()
		*******************************************************************************/

		internal void DroplistSelectedItemChanged(object value)
		{
			var brushInfo = (BrushInfo)value;

			switch (Variety)
			{
				case BrushVariety.Solid:
					lastSolidBrushInfo = brushInfo;
					break;
				case BrushVariety.LinearGradient:
					lastLinearGradientBrushInfo = brushInfo;
					break;
				case BrushVariety.RadialGradient:
					lastRadialGradientBrushInfo = brushInfo;
					break;
				case BrushVariety.Image:
					lastImageBrushInfo = brushInfo;
					break;
			}

			SyncBrushToDropdown();
		}

		/*******************************************************************************
			VarietyChanged()
		*******************************************************************************/

		internal void VarietyChanged(object value)
		{
			if (!(value is BrushVariety))
				return;

			var brushVariety = (BrushVariety)value;

			switch (brushVariety)
			{
				case BrushVariety.None:
					Prep(null, null);
					break;
				case BrushVariety.Solid:
					Prep(SolidColorBrushes.Singleton.All, lastSolidBrushInfo);
					break;
				case BrushVariety.LinearGradient:
					Prep(LinearGradientBrushes.Singleton.All, lastLinearGradientBrushInfo);
					break;
				case BrushVariety.RadialGradient:
					Prep(RadialGradientBrushes.Singleton.All, lastRadialGradientBrushInfo);
					break;
				case BrushVariety.Image:
					Prep(ImageBrushes.Singleton.All, lastImageBrushInfo);
					break;
			}

			void Prep(IList<BrushInfo> brushes, BrushInfo last)
			{
				if (null == brushes)
				{
					E_droplist.Visibility = Lesarde.Frogui.Visibility.Collapsed;
					E_droplist.ItemsSource = null;
					Brush = null;
				}
				else
				{
					E_droplist.Visibility = Lesarde.Frogui.Visibility.Visible;
					E_droplist.ItemsSource = brushes;
					E_droplist.SelectedItem = last ?? brushes[0];
					SyncBrushToDropdown();
				}
			}
		}

		/*******************************************************************************
			BrushChanged()
		*******************************************************************************/

		internal void BrushChanged(Brush oldBrush, Brush newBrush)
		{
			var brush = this.Brush;

			if (AvoidRecursion)
				return;

			// Null brush
			if (null == brush)
				SyncVariety(BrushVariety.None);

			// SolidColorBrush
			else if (brush is SolidColorBrush solidColorBrush)
			{
				SyncVariety(BrushVariety.Solid);
				var index = SolidColorBrushes.Singleton.IndexOf(brush);
				if (-1 == index)
				{
					for (var i = 0; i < SolidColorBrushes.Singleton.All.Count; ++i)
					{
						var cur = (SolidColorBrush)SolidColorBrushes.Singleton.All[i].Brush;

						if (cur.Color == solidColorBrush.Color)
						{
							index = i;
							break;
						}
					}
				}

				Debug.Assert(-1 != index);
				E_droplist.SelectedItem = SolidColorBrushes.Singleton.All[index];
			}

			// LinearGradientBrush
			else if (brush is LinearGradientBrush)
				SyncControls(BrushVariety.LinearGradient, LinearGradientBrushes.Singleton);

			// RadialGradientBrush
			else if (brush is RadialGradientBrush)
				SyncControls(BrushVariety.RadialGradient, RadialGradientBrushes.Singleton);
			// ImageBrush
			else if (brush is ImageBrush)
				SyncControls(BrushVariety.Image, ImageBrushes.Singleton);
			// error
			else
				throw new System.Exception("Unrecognized brush");

			void SyncControls(BrushVariety variety, Brushes brushes)
			{
				SyncVariety(variety);
				//me.E_slider.Value = brushes.IndexOf(brush);
				this.E_droplist.SelectedItem = brushes.Find(brush);
			}

			void SyncVariety(BrushVariety variety)
			{

				this.E_varietySelector.SelectBySegmentValue(variety);
			}
		}

		/*******************************************************************************
			SyncBrushToSlider()
		*******************************************************************************/

		void SyncBrushToDropdown()
		{
			//if (null != Brushes)
			//Brush = Brushes.All[(int)E_slider.Value].Brush;
			var brushInfo = (BrushInfo)E_droplist.SelectedItem;
			Brush = brushInfo?.Brush;
		}

		/*******************************************************************************
			BindToSourceProperty()
		*******************************************************************************/

		void IPropertyEditor.BindToSourceProperty(DependencyObject sourceObject, DependencyProperty sourceProperty)
		{
			SetBinding(BrushProperty, new Binding(sourceProperty, sourceObject) { Mode = BindingMode.TwoWay });
		}
	}
}
#endif
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

		IModelViewMatcher DroplistItemViewMatcher { get; } = new SingleModelViewMatcher(typeof(BrushInfoView));

		/***********************************************************
			element properties
		***********************************************************/

		static readonly Length MARGIN = Length.InPixels(8);

		Grid E_Grid { get; } = new Grid() { Margin = Thickness.InPixels(8) };

		VarietySelector E_varietySelector { get; } = new VarietySelector() { Margin = new Thickness(Length.ZeroPx, Length.ZeroPx, MARGIN, Length.ZeroPx), Width = Length.InPixels(260) };

		Droplist E_droplist_solidColor { get; }
		Droplist E_droplist_linearGradient { get; }
		Droplist E_droplist_radialGradient { get; }
		Droplist E_droplist_image { get; }

		Droplist E_droplist_currrent
		{
			get
			{
				switch (Variety)
				{
					case BrushVariety.Solid: return E_droplist_solidColor;
					case BrushVariety.LinearGradient: return E_droplist_linearGradient;
					case BrushVariety.RadialGradient: return E_droplist_radialGradient;
					case BrushVariety.Image: return E_droplist_image;
					default: return null;
				}
			}
		}

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
			E_droplist_solidColor = CreateDroplist(SolidColorBrushes.Singleton.All);
			E_droplist_linearGradient = CreateDroplist(LinearGradientBrushes.Singleton.All);
			E_droplist_radialGradient = CreateDroplist(RadialGradientBrushes.Singleton.All);
			E_droplist_image = CreateDroplist(ImageBrushes.Singleton.All);

			this.BorderThickness = Thickness.InPixels(1);
			this.BorderBrush = SolidColorBrushes.Gray.Brush;

			this.Child = E_Grid;

			E_Grid.ColumnCount = 2;
			E_Grid.RowCount = 2;

			E_Grid.Children.Add(E_varietySelector, new GridAnchor(0, 0));
			E_Grid.Children.Add(E_preview, new GridAnchor(1, 0, 1, 2));

			E_varietySelector.SelectedItem = E_varietySelector.Items[0];
			E_varietySelector.AddPropertyChangedListener(Selector.SelectedValueProperty, VarietyChanged);

			//E_droplist.ItemViewMatcher = new SingleModelViewMatcher(typeof(BrushInfoView));
			//E_droplist.AddPropertyChangedListener(Droplist.SelectedItemProperty, DroplistSelectedItemChanged);

			E_preview.SetBinding(Border.BackgroundProperty, new Binding(BrushProperty, this));
		}

		/*******************************************************************************
			CreateDroplist()
		*******************************************************************************/

		Droplist CreateDroplist(IList<BrushInfo> brushes)
		{
			var droplist = new Droplist()
			{
				Margin = new Thickness(Length.ZeroPx, MARGIN, MARGIN, Length.ZeroPx),
				Width = Length.InPixels(260),
#if ! wait
				ItemsSource = brushes,
				SelectedIndex = 0,
#endif
				ItemViewMatcher = DroplistItemViewMatcher,
				Visibility = Visibility.Collapsed
			};

			droplist.AddPropertyChangedListener(Droplist.SelectedItemProperty, DroplistSelectedItemChanged);

			E_Grid.Children.Add(droplist, new GridAnchor(0, 1));

			return droplist;
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

			E_droplist_solidColor.Visibility = GetVis(BrushVariety.Solid);
			E_droplist_linearGradient.Visibility = GetVis(BrushVariety.LinearGradient);
			E_droplist_radialGradient.Visibility = GetVis(BrushVariety.RadialGradient);
			E_droplist_image.Visibility = GetVis(BrushVariety.Image);

			SyncBrushToDropdown();

			Visibility GetVis(BrushVariety variety) => (this.Variety == variety) ? Visibility.Visible : Visibility.Collapsed;
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
#if ! wait
				E_droplist_solidColor.SelectedItem = SolidColorBrushes.Singleton.All[index];
#endif
			}

			// LinearGradientBrush
			else if (brush is LinearGradientBrush)
				SyncControls(E_droplist_linearGradient, BrushVariety.LinearGradient, LinearGradientBrushes.Singleton);

			// RadialGradientBrush
			else if (brush is RadialGradientBrush)
				SyncControls(E_droplist_radialGradient, BrushVariety.RadialGradient, RadialGradientBrushes.Singleton);
			// ImageBrush
			else if (brush is ImageBrush)
				SyncControls(E_droplist_image, BrushVariety.Image, ImageBrushes.Singleton);
			// error
			else
				throw new System.Exception("Unrecognized brush");

			void SyncControls(Droplist droplist, BrushVariety variety, Brushes brushes)
			{
				SyncVariety(variety);
				droplist.SelectedItem = brushes.Find(brush);
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
			if (BrushVariety.None == Variety)
				Brush = null;
			else
			{
				var brushInfo = (BrushInfo)E_droplist_currrent.SelectedItem;
				Brush = brushInfo?.Brush;
			}
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

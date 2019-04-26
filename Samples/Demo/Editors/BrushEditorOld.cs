using Lesarde;
using Lesarde.Frogui;
using Lesarde.Frogui.ComponentModel;
using Lesarde.Frogui.Controls;
using Lesarde.Frogui.Controls.Primitives;
using Lesarde.Frogui.Data;
using Lesarde.Frogui.Media;
using System.Diagnostics;

namespace Demo
{
	/***************************************************************************************************
		BrushEditorOld class
	***************************************************************************************************/

	public class BrushEditorOld : Grid, IPropertyEditor
    {
		/***********************************************************
			VarietySegmentor class
		***********************************************************/

		public class VarietyEditor : EnumImageEditor<BrushVariety>
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

			//public VarietyEditor(BrushVariety varieties)
			//{
			//	this.Varieties = varieties;
			//}
		}

		/***********************************************************
			Last used brush index variables
		***********************************************************/

		decimal
			lastSolidIndex,
			lastLinearGradientIndex,
			lastRadialGradientIndex,
			lastImageIndex;

		/***********************************************************
			element properties
		***********************************************************/

		VarietyEditor E_varietyEditor { get; } = new VarietyEditor();

		BrushSlider E_slider { get; } = new BrushSlider() { Margin = new Thickness(new Length(8, Unit.Px), Length.ZeroPx, Length.ZeroPx, Length.ZeroPx) };

		/***********************************************************
			AvoidRecursion property
		***********************************************************/

		bool AvoidRecursion { get; set; }

		/***********************************************************
			Brush property
		***********************************************************/

		public static DependencyProperty<Brush, BrushEditorOld> BrushProperty { get; } = DependencyProperty<Brush, BrushEditorOld>
			.Register()
			.Changed((me, e) =>
			{
			var brush = e.NewValue;

				if (me.AvoidRecursion)
					return;

				if (null == brush)
					SyncVariety(BrushVariety.None);
				else if (brush is SolidColorBrush solidColorBrush)
					//SyncControls(BrushVariety.Solid, SolidColorBrushes.Singleton);
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
					me.E_slider.Value = index;
				}

				else if (brush is LinearGradientBrush)
					SyncControls(BrushVariety.LinearGradient, LinearGradientBrushes.Singleton);
				else if (brush is RadialGradientBrush)
					SyncControls(BrushVariety.RadialGradient, RadialGradientBrushes.Singleton);
				else if (brush is ImageBrush)
					SyncControls(BrushVariety.Image, ImageBrushes.Singleton);
				else
					throw new System.Exception("Unrecognized brush");

				void SyncControls(BrushVariety variety, Brushes brushes)
				{
					SyncVariety(variety);
					me.E_slider.Value = brushes.IndexOf(brush);
				}

				void SyncVariety(BrushVariety variety)
				{
					me.E_varietyEditor.SelectBySegmentValue(variety);
				}
			});

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
			SliderToRight property
		***********************************************************/

		public bool SliderToRight
		{
			get => sliderToRight;

			set
			{
				sliderToRight = value;

				if (value)
				{
					RowCount = 1;
					ColumnCount = 2;
					E_slider.Anchor = new GridAnchor(1, 0);
				}
				else
				{
					RowCount = 2;
					ColumnCount = 1;
					E_slider.Anchor = new GridAnchor(0, 1);
				}
			}
		}

		bool sliderToRight;

		/***********************************************************
			Varieties property
		***********************************************************/

		//protected virtual BrushVariety Varieties { get; } = BrushVariety.None | BrushVariety.Solid | BrushVariety.LinearGradient | BrushVariety.RadialGradient | BrushVariety.Image;

		/***********************************************************
			Variety property
		***********************************************************/

		BrushVariety Variety => (BrushVariety)((Segment)E_varietyEditor.SelectedItem).Value;

		/***********************************************************
			Brushes property
		***********************************************************/

		Brushes Brushes => (Brushes)E_slider.Items;

		/*******************************************************************************
			$
		*******************************************************************************/

		public BrushEditorOld()
		{
//			E_varietyEditor = new VarietyEditor(Varieties);

			lastSolidIndex = 0;
			lastLinearGradientIndex = 0;
			lastRadialGradientIndex = 0;
			lastImageIndex = 0;

			E_varietyEditor.SelectedItem = E_varietyEditor.Items[0];

			E_varietyEditor.AddPropertyChangedListener(Selector.SelectedValueProperty, (value) =>
				{
					if (!(value is BrushVariety))
						return;

					switch ((BrushVariety)value)
					{
						case BrushVariety.None:
							Prep(null, 0);
							break;
						case BrushVariety.Solid:
							Prep(SolidColorBrushes.Singleton, lastSolidIndex);
							break;
						case BrushVariety.LinearGradient:
							Prep(LinearGradientBrushes.Singleton, lastLinearGradientIndex);
							break;
						case BrushVariety.RadialGradient:
							Prep(RadialGradientBrushes.Singleton, lastRadialGradientIndex);
							break;
						case BrushVariety.Image:
							Prep(ImageBrushes.Singleton, lastImageIndex);
							break;
					}

					void Prep(Brushes brushes, decimal last)
					{
						if (null == brushes)
						{
							E_slider.Visibility = Lesarde.Frogui.Visibility.Collapsed;
							E_slider.Items = null;
							Brush = null;
						}
						else
						{
							E_slider.Visibility = Lesarde.Frogui.Visibility.Visible;
							E_slider.Items = brushes;
							E_slider.Value = last;
							E_slider.RefreshUserValues();
							SyncBrushToSlider();
						}
					}
				});

			E_slider.AddPropertyChangedListener(BrushSlider.ValueProperty, (value) =>
			{
				switch (Variety)
				{
					case BrushVariety.Solid:
						lastSolidIndex = value;
						break;
					case BrushVariety.LinearGradient:
						lastLinearGradientIndex = value;
						break;
					case BrushVariety.RadialGradient:
						lastRadialGradientIndex = value;
						break;
					case BrushVariety.Image:
						lastImageIndex = value;
						break;
				}

				SyncBrushToSlider();
			});

			Children.Add(E_varietyEditor, new GridAnchor(0, 0));
			Children.Add(E_slider);
			SliderToRight = false;
		}

		/*******************************************************************************
			SyncBrushToSlider()
		*******************************************************************************/

		void SyncBrushToSlider()
		{
			if (null != Brushes)
				Brush = Brushes.All[(int)E_slider.Value].Brush;
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
